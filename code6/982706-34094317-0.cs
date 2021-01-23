    public Vector3 towerSize = new Vector3(3, 3, 3);
    
    	public GameObject tiles;
    	public GameObject randomTile;
    
    //public variables for debugging purposes.
    //no real need to be seen in inspector in final.  cleaner too if they're hidden
    	public int randomSelectedTile;
    
    	public List<GameObject> allTiles;
    
    	void Start()
    	{
    		//create grid tower
    		for (int x = 0; x < towerSize.x; x++)
    		{
    			for (int z = 0; z < towerSize.z; z++)
    			{
    				for (int y = 0; y < towerSize.y; y++)
    				{
    					//spawn cubes and space them
    					GameObject obj = (GameObject)Instantiate(tiles);
    					obj.transform.position = new Vector3(x * 1.2f, y * 1.2f, z * 1.2f);
    					
    					//add them all to a List
    					allTiles.Add(obj);
    					obj.name = "tile " + allTiles.Count;
    				}
    			}
    		}
    
    		//select a random cube in the list
    		randomSelectedTile = Random.Range(0, allTiles.Count);
    
    		//get the cube object to delete
    		GameObject deleteObj = allTiles.ElementAt(randomSelectedTile);
    		//spawn the random cube at the position of the cube we will delete
    		GameObject rndObj = (GameObject)Instantiate(randomTile);
    		rndObj.transform.position = deleteObj.transform.position;
    
    		//remove the element at that location
    		allTiles.RemoveAt(randomSelectedTile);
    		//insert the random cube at that element's location
    		allTiles.Insert(randomSelectedTile, rndObj);
    
    		//destroy the unwanted cube
    		Destroy(deleteObj);
    	}
