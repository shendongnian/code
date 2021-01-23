    void Spawner ()
    {
        //create a local list of spawn points
        List<Transform> availablePoints = new List<Transform>(spawnPoints);
        // Create an instance of the enemy prefab at the randomly selected spawn point's position.
        //Create the enemies at a random transform 
        for (int i = 0; i<m_enemyCount;i++)
        {
            //use local availableSpawnPoints instead of your global spawnPoints to generate spawn index
            int spawnPointIndex = Random.Range (0, availableSpawnPoints.Count);
            Transform pos = spawnPoints[spawnPointIndex];
            GameObject InstanceEnemies= Instantiate ( enemy[index] , spawnPoints[spawnPointIndex].position , Quaternion.identity) as GameObject;
            // Create enemies and add them to our list.
            EnemiesList.Add(InstanceEnemies);
           //remove the used spawnpoint
           availableSpawnPoints.RemoveAt(spawnPointIndex);
        }
    }
