    using UnityEngine;
    using System.Collections;
    
    public class BigDoorScript : MonoBehaviour
    {
        
        private bool doorOpen = false;
    	private Ray ray;
    	private RaycastHit hit;
    	private float distance = 5.0f;
    	
    	private void Update()
    	{
    		if (Input.GetKeyDown("e"))
    		{
    			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    			if (Physics.Raycast(ray, out hit, distance))
    			{
    				if(hit.collider.gameObject.name == "door"){//Check that your ray is colliding with the door
    					if (!doorOpen)
    					{
    						hit.transform.Translate(new Vector3(0.0f, 0.0f, 4.0f));
    						doorOpen = true;
    					}
    					else
    					{
    						hit.transform.Translate(new Vector3(0.0f, 0.0f, -4.0f));
    						doorOpen = false;
    					}
    				}
    			}
    		}
    	}
    }
