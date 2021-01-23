    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    public class MouseDownText : MonoBehaviour {
    public Canvas myCanvas;
	// Use this for initialization
	void Start () {
	
		myCanvas = GetComponent<Canvas> ();
		myCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
    void OnMouseDown()
	{
		// for switch on/off
		if (myCanvas.enabled)
			myCanvas.enabled = false;
		else
			myCanvas.enabled = true;
	}
    } 
