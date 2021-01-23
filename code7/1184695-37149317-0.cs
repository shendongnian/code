    Transform _player;
    NavMeshAgent nav;
    void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        if(playerObjects.Length>1) 
        {
            Debug.LogError("You have multiple player objects in the scene!");
        }
        _player = playerObjects[0].transform;
        nav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        nav.SetDestination(_player.position);     
    }
