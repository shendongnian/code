    using UnityEngine;
    using System.Collections;
    public class FirstPersonController : MonoBehaviour 
    {
	    public float mouseSensitivity = 1.0f;
	    float mouseRotY = 0.0f;
	
	    public bool inverted = false;
	    private float invertedCorrection = 1.0f;
	    void FixedUpdate ()
	    {
		    if(Input.GetAxis ("Fire1") > 0.0f)
		    	inverted = !inverted;
	    	if(inverted)
	    		invertedCorrection = -1.0f;
	    	else
	    		invertedCorrection = 1.0f;
    
	    	mouseRotY -=  invertedCorrection * Input.GetAxis("Mouse Y") * mouseSensitivity;
	    	mouseRotY = Mathf.Clamp(mouseRotY, -90.0f, 90.0f);
	    	Camera.main.transform.localRotation = Quaternion.Euler(mouseRotY, 0.0f, 0.0f); 
	    }
    }
