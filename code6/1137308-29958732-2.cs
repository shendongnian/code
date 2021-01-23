    using UnityEngine;
    using System.Collections;
    public class Test : MonoBehaviour {
	
	Camera cam;
	Transform t;
	void Start () {
		cam = Camera.main;
		t = cam.transform;
	}
	void OnGUI()
	{
		if (GUILayout.Button ("Rotate (10,0,0)")) {
			t.Rotate(new Vector3(10,0,0));
			PlayerPrefs.SetFloat("rX", t.rotation.x); // Save
			PlayerPrefs.SetFloat("rY", t.rotation.y);
			PlayerPrefs.SetFloat("rZ", t.rotation.z);
			PlayerPrefs.Save ();			                              
		}
		if (GUILayout.Button ("Reload Camera Euler angle")) {
			
			var x= PlayerPrefs.GetFloat("rX"); // Load
			var y= PlayerPrefs.GetFloat("rY");
			var z= PlayerPrefs.GetFloat("rZ");
			cam.transform.rotation = Quaternion.Euler(x,y,z);                       
		}
	}
    }
