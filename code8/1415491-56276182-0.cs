    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class SelectObject : MonoBehaviour {
    
    	// Use this for initialization
    	GameObject hitObj;
    	RaycastHit hit;
    	private float speed = 1;
    
    	void Start () {
    		
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		foreach (Touch touch in Input.touches) {
    			switch (touch.phase) {
    				case TouchPhase.Began:
    					Ray ray = Camera.main.ScreenPointToRay (touch.position);
    					if (Physics.Raycast (ray, out hit, 10)) {
    							hitObj = hit.collider.gameObject;
    					}
    					break;
    			case TouchPhase.Moved:
    				
    				// If the finger is on the screen, move the object smoothly to the touch position          
    				float step = speed * Time.deltaTime; // calculate distance to move
    				if(hitObj != null)
    					hitObj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3 (touch.position.x, touch.position.y, hitObj.transform.position.z));
    				break;
    			}
    		}
    	}
    }
