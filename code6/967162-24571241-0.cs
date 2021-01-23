    public GameObject[] obj; // for your enemies, using array so you can put many kind of enemy prefabs
    public float spawnMin = 1f; //your minimum time enemies spawn
    public float spawnMax = 2f; //your maximum time enemies spawn
    
    void Start () 
    {
    	spawn();
    }
    
    void spawn()
    {
    	Instantiate(obj[Random.Range(0, obj.GetLength(0))], //instantiate random prefabs
    		new Vector3(transform.position.x, transform.position.y, z), 
    		Quaternion.identity)
    		
    	//this is the one that control how many times spawn called
    	Invoke("Spawn", Random.Range(spawnMin, spawnMax)); 
    }
