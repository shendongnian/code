    using UnityEngine;
    using System.Collections;
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mouse : MonoBehaviour {
    	
    	Rigidbody2D body;
    	float mousePosInBlocks;
    	
    	void Start () {
    		body = GetComponent<Rigidbody2D> ();
    	}
    	
    	void Update () {
    		
    		if (Input.GetMouseButtonDown (0)) {
    			
    			body.isKinematic = false;
    			
    		}
    		
    		Vector3 ballPos = new Vector3 (0f, this.transform.position.y, 0f);
    
    		mousePosInBlocks = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    		
    		//restrict the position not outside
    		ballPos.x = Mathf.Clamp (mousePosInBlocks, -2.65f, 2.65f);
    		
    		body.position = ballPos;
    	}
    }
