    //this assumes that your script is on your player
    
    //assign these in the inspector
    public GameObject leftRoad, centerRoad, rightRoad; //the empty gameobjects which lie in the center of your roads
    
    void Update()
    {
    	if (Input.GetKey("left"))
        {
    		// Change direction to left
            transform.position = leftRoad.position;
    
        }
        if (Input.GetKey("right"))
        {
            // Change direction to right
    		transform.position = rightRoad.position;
        }    
        
    	gameObject.transform.position = Vector3.Lerp(direction, endPosition, speed);
    }
