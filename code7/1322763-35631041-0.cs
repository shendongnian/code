    void CannonKiller()
    	{
    		foreach(var cannon in GameObject.FindGameObjectsWithTag("EnemyCannon").Select(enemyCans => enemyCans.transform).ToArray())
    		{
    			foreach (var aCan in enemyCans)
    			{
    				float enemyDis = Vector3.Distance(cannon.position, transform.position);
    				if (enemyDis <= 4)
    				{
    					Destroy(aCan);
    
    					bool allDestoyed = true;
    					foreach (GameObject o in enemyCans) 
    					{
    						if (o != null) 
    						{
    							allDestoyed = false;
    							break;
    						}
    					}
    
    					if (allDestoyed) 
    					{
    						// Here you know all are destroyed
    					}
    				}
    			}
    		}
    	}
