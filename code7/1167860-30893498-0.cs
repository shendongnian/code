     using UnityEngine;
    using System.Collections;
    
    public class CameraManager : MonoBehaviour {
    	
    	public LookAtCamera lookAtScript;
    	public MouseLook mouseLookScript;
    	
    	void Update () {
    		if (Input.GetKey (KeyCode.Mouse1)) {
    			lookAtScript.enabled = false;
    			mouseLookScript.enabled = true;
    		} else {
    			mouseLookScript.enabled = false;
    			lookAtScript.enabled = true;
    
    		}
    	}
    }
