    // Movement speed normalized. So 1 is instantaneous travel and zero is no movement.
    public float movementSpeed = 0.025;
    // Let's add a 'pause' time where the unit waits a while at the turning point.
    public float waitTime = 1;
    // Lets say the list has 5 points.
    public List<Vector3> patrolPoints ... 
    // We keep track of our starting and ending points. Here we start at zero and move to position 1.
    public Vector2 currentLeg = new Vector2(0,1);
    
    // We use a coroutine
    IEnumerator Patrol()
    {
    	// This keeps track of where we are. 0 is at the starting point and 1 is at the destination.
    	float progress = 0;
    
    	while(true)
    	{
    			Vector3 startingPoint = patrolPoints[currentLeg.x];
    			Vector3 destination = patrolPoints[currentLeg.y];
    			
    			// Please note this won't compile. It's for brevity. You must lerp x,y,z indiviualy in C#.
    			transform.position = Mathf.Lerp(startingPoint, destination, progress);
    			progress+= movementSpeed;
    			
    			// If we are at our destination
    			if(progress >=1 )
    			{
    				// Reset our progress so wa can start over.
    				progress = 0;
    				
    				// Our current point is now what our destination was before.
    				currentLeg.x = currentLeg.y;
    				
    				switch(moveType)
    				{
    					case MoveType.Forward: 
    					{
    						// If this condition is true then it means we are at the final point (4 in this case). So we invert the movement direction and set the current point to 3.
    						if(currentLeg.y == patrolPoints.Count()-1)
    						{
    							currentLeg.y -= 1;
    							moveType = MoveType.Backwards;
	
    				           // We wait 1 seconds and then do everything again.
    				           yield return new WaitForSeconds(waitTime);
    						}
    						else
    							currentLeg.y++;
    					}
    					break;
    					case MoveType.Backward:
    					{
    						// If this condition is true then it means we are at the starting point (0). So we invert the movement direction and set the current point to 1.
    						if(currentLeg.y == 0)
    						{
    							currentLeg.y += 1;
    							moveType = MoveType.Forward;
	
    				            // We wait 1 seconds and then do everything again.
    				            yield return new WaitForSeconds(waitTime);
    						}
    						else
    							currentLeg.y--;
    					}
    					break;
    				}
    			
    			}
    	}
    }
