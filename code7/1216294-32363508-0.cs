    using UnityEngine;
    using System.Collections;
    public class Movement1 : MonoBehaviour 
    {
	
	public float yMin, yMax; // be sure to set these in the inspector
	void Update () 
	{
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.up * Time.deltaTime * 10);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.down * Time.deltaTime * 10);
			
		}
	
        float clampedY = Mathf.Clamp(transform.localPosition.y,yMin,yMax);
        transform.localPosition = new Vector3 (transform.localPosition.x, clampedY, transform.localPosition.z);
	}
 	
    }
