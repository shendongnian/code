    public static List<ChunkTerrainData> ListOfChunks = new List<ChunkTerrainData>();
    //Start()
    ChunkData = GenerateTerrain(ThisChunkOriginX, ThisChunkOriginZ, WithChunkData);
    ChunkData.InventoryGameObjects = new List<GameObject>();
    ListOfChunks.Add(ChunkData);
    //Update()
    GameObject Tree = (GameObject)Instantiate(Tree_a, InstatiateTreeStone_Position, InstatiateTreeStone_Rotation);
    Tree.transform.parent = TerrainMesh.transform;
    ListOfChunks[i].InventoryGameObjects.Add(Tree);   //some ListOfChunks
