    //Add the random objects in the inspector
    public List<GameObject> gameObjects;
    //Spawn points around the terrain
    public List<Transform> emptyTransforms;
        
    foreach(var item in emptyTransforms){
        var objToSpawn = gameObjects[Random.Range(0, gameObjects.Length)];
        Instantiate(objToSpawn, emptyTransforms[Random.Range(0, emptyTransforms.Length)].position, Quaternion.identity);
    }
