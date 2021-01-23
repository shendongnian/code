    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    public class test : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Color img = gameObject.GetComponent<Image> ().color;
		img.b = Mathf.Lerp (img.b, 0, Time.deltaTime);
		img.g = Mathf.Lerp (img.g, 0, Time.deltaTime);
		gameObject.GetComponent<Image> ().color = img;
	    }
    }
