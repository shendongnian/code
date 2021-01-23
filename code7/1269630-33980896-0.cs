    using UnityEngine;
    using System.Collections;
    using System.Diagnostics;
    public class Overlay : MonoBehaviour {
	    bool onlyOnce = true;
	    // Use this for initialization
	    void Start () {
	    	if (onlyOnce) {
		    	Process p = Process.Start (@"Overlay.exe"); //Change to the exe of your form
			    onlyOnce = false;
		    }
	    }
	
	    // Update is called once per frame
	    void Update () {
	
	    }
    }
