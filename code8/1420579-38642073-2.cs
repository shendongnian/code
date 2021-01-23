    private void MoveTileToFront(GameObject tile)
    {
        tile.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
    }
    private GameObject SpawnTileAtFront(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        MoveTileToFront(go);
        return go;
    }
