    using UnityEngine;
    
    public class MoveController : MonoBehaviour {
    	float angle = 1F;
    	float speed = 0.2F;
    	void Update ()
    	{
    		if ( Input.GetKey (KeyCode.LeftArrow) )
    			transform.Rotate(Vector3.up, -angle);
    		else if( Input.GetKey (KeyCode.RightArrow) )
    			transform.Rotate(Vector3.up, angle);
    
    		transform.Translate(Vector3.forward * speed);
    	}
    }
