    ...
    
    private List<Transform> freePositions;
    private List<Transform> occupiedPositions;
    private void Start()
    {
        freePositions = new List<Transform>(spawnPoints);
        occupiedPositions = new List<Transform>();
        
        SpawnObstacles();
    }
    private void SpawnObstacles()
    {
        // just use this for initial obstacles
        // call Spawn as often as needed
        for(int i = 0; i < noOfObstacles; i++)
        {
            Spawn();
        }
    }
    public void SpawnNewObstacle(Vector3 freePos)
    {
        for(int i = 0; i < occupiedPositions.Count; i++)
        {
            if(occupiedPositions[i].position == freePos)
            {
                freePositions.Add(occupiedPositions[i]);
                occupiedPositions.RemoveAt(i);
                break;
            }
        }
        // and call Spawn
        Spawn();
    }
    private void Spawn()
    {
        // this is simplified
        int index = Random.Range(0, freePositions.Count);
        Obstacle obs = ((GameObject)Instantiate(obstaclePrefab, freePositions[index], Quaternion.identity).GetComponent<Obstacle>();
        obs.SetManagerReference(this);
        occupiedPositions.Add(freePositions[index]);
        freePositions.RemoveAt(index);
    }
