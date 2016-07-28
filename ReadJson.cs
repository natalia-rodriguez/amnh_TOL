using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;
using LitJson;

public class ReadJson : MonoBehaviour {

	private string jsonString;
	private JsonData itemData; // actually holds data
	public Transform target;

	public GameObject sprite1; 


	// Use this for initialization
	void Start () {
		jsonString = File.ReadAllText (Application.dataPath + "/mammals.json"); //will get us to that assets folderå

		itemData = JsonMapper.ToObject (jsonString);
		Debug.Log(itemData.Count);
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(Color.white, Color.white);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.SetVertexCount(84);




		for (int i = 0; i < itemData.Count - 1; i++) {
			Debug.Log (itemData [i] ["mya"]);
			string mya = (string)itemData [i] ["mya"];
			int age = System.Convert.ToInt32 (mya);
			Debug.Log (age);
			//Instantiate (sphere, new Vector3 (i * 1f, age * .06f, 0), Quaternion.identity);
			Instantiate(sprite1, new Vector3 (i * 1f, age * .06f, 0), Quaternion.identity);


			//Draw Line
			lineRenderer.SetPosition (i, new Vector3 (i * 1f, age * .06f, 0));


		}

	}


	void OnGUI() {
		jsonString = File.ReadAllText (Application.dataPath + "/mammals.json"); //will get us to that assets folderå

		itemData = JsonMapper.ToObject (jsonString);

		for (int i = 0; i < itemData.Count - 1; i++) {
			string name = (string)itemData [i] ["commonName"];
			string mya = (string)itemData [i] ["mya"];
			int age = System.Convert.ToInt32 (mya);
			Vector3 position = new Vector3 (i * 1f, age * .06f, 0);
			Handles.Label(position, name);
		}
	}
	
	// Update is called once per frame
	void Update () {
//		LineRenderer lineRenderer = GetComponent<LineRenderer>();
//		lineRenderer.SetPosition (0, new Vector3 (i * 1f, age * .05f, 0));
	}
}
