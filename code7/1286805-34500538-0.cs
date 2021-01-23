    void  Update ()
    	{
    		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) { //pomicanje trake po x-osi na touch screenu
    			// pokret prsta od zadnjeg frejma
    			Vector3 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
    			// Za x-os
    			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (Mathf.Clamp (touchDeltaPosition.x, -2.5f, 2.5f), 0, transform.position.z), 1);
    		}
    	}
