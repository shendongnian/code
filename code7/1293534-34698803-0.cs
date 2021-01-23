    public class TerrainManager : MonoBehaviour, ICameraObserver {
    public Terrain mainTerrain;
    public float terrainChangeRate = 0.0001f;
    public int brushArea = 20;
    public static int viewDistance = 9;
    public static Vector2 VECTOR_WILDCARD = new Vector2(-10000, -10000);
    int resolutionX;
    int resolutionY;
    float[,] heights;
    int heightEdit = 1;
    //Chunks
    List<Vector2> loadedChunks = new List<Vector2>();
    Vector2[] visibleChunks = null;
    Terrain[] chunkGraphics = new Terrain[viewDistance];
    Vector2 curChunkIndex = new Vector2();
    int chunkSizeX = 256;
    int chunkSizeY = 256;
	// Use this for initialization
	void Start () {
        resolutionX = mainTerrain.terrainData.heightmapWidth;
        resolutionY = mainTerrain.terrainData.heightmapHeight;
        heights = mainTerrain.terrainData.GetHeights(0, 0, resolutionX, resolutionY);
        Camera.main.GetComponent<RTSCamera>().Subscribe(this);
        GameObject world = new GameObject();
        world.name = "World";
        for (int i = 0; i < viewDistance; i++)
        {
            GameObject go = new GameObject();
            go.name = "Chunk_" + i;
            go.transform.SetParent(world.transform);
            chunkGraphics[i] = go.AddComponent<Terrain>();
            chunkGraphics[i].terrainData = new TerrainData();
            go.AddComponent<TerrainCollider>().terrainData = chunkGraphics[i].terrainData;
            chunkGraphics[i].terrainData.size = new Vector3((int)(chunkSizeX / 4), 600, (int)(chunkSizeY / 4));
            chunkGraphics[i].terrainData.heightmapResolution = (int)(chunkSizeX / 2);
        }
        onCameraMove(Camera.main.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                editTerrainHeight(hit.point, terrainChangeRate, brushArea);
            }
        }
	}
    void editTerrainHeight(Vector3 position, float amount, int diameter)
    {
        int terrainPosX = (int)((position.x / mainTerrain.terrainData.size.x) * resolutionX);
        int terrainPosY = (int)((position.z / mainTerrain.terrainData.size.z) * resolutionY);
        float[,] heightChange = new float[diameter, diameter];
        int radius = diameter / 2;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            heightEdit = -1;
        }
        else
        {
            heightEdit = 1;
        }
        amount = amount * heightEdit;
        for (int x = 0; x < diameter; x++)
        {
            for (int y = 0; y < diameter; y++)
            {
                int x2 = x - radius;
                int y2 = y - radius;
                heightChange[y, x] = heights[terrainPosY + y2, terrainPosX + x2] + amount;
                heights[terrainPosY + y2, terrainPosX + x2] = heightChange[y, x];
            }
        }
        mainTerrain.terrainData.SetHeights(terrainPosX - radius, terrainPosY - radius, heightChange);
    }
    public void onCameraMove(Vector3 newCameraPosition)
    {
        //Debug.Log ("Camera Moved");
		int chunkIndexX = Mathf.FloorToInt (newCameraPosition.x / chunkSizeX);
		int chunkIndexY = Mathf.FloorToInt (newCameraPosition.z / chunkSizeY);
		if (curChunkIndex.x == chunkIndexX && curChunkIndex.y == chunkIndexY) {
			return;
		}
		curChunkIndex.x = chunkIndexX;
		curChunkIndex.y = chunkIndexY;
		//Debug.Log ("Chunk Index ( " + chunkIndexX + ", " + chunkIndexY + " )");
		Vector2[] newVisibleChunks = new Vector2[9];
		newVisibleChunks [0] = new Vector2 (chunkIndexX -1, chunkIndexY +1);
		newVisibleChunks [1] = new Vector2 (chunkIndexX, chunkIndexY +1);
		newVisibleChunks [2] = new Vector2 (chunkIndexX +1, chunkIndexY +1);
		newVisibleChunks [3] = new Vector2 (chunkIndexX -1, chunkIndexY);
		newVisibleChunks [4] = new Vector2 (chunkIndexX, chunkIndexY);
		newVisibleChunks [5] = new Vector2 (chunkIndexX +1, chunkIndexY);
		newVisibleChunks [6] = new Vector2 (chunkIndexX -1, chunkIndexY -1);
		newVisibleChunks [7] = new Vector2 (chunkIndexX, chunkIndexY -1);
		newVisibleChunks [8] = new Vector2 (chunkIndexX +1, chunkIndexY -1);
		Terrain[] newChunkGraphics = new Terrain[chunkGraphics.Length]; 
		List<int> freeTerrains = new List<int>();
		List<int> loadingIndexes = new List<int>();
		//List<int> newIndex = new List<int>();
		for (int i =0; i <9; i++) {
			bool found =  false;
			for (int j =0; j <9; j++) {
				if (visibleChunks == null)
					break;
				if (newVisibleChunks[i].Equals (visibleChunks[j])){
					visibleChunks[j] = VECTOR_WILDCARD;
					newChunkGraphics[i] = chunkGraphics[j];
					found = true;
					break;
				}
			}
			if (!found){
				loadingIndexes.Add (i);
			}
		}
		if (visibleChunks != null) {
			for (int i = 0; i< 9; i++) {
				if (visibleChunks [i] != VECTOR_WILDCARD) {
					freeTerrains.Add (i);
					saveChunkToMemory (chunkGraphics [i], visibleChunks [i]);
				
				
				}
			}
		} else {
			for (int i = 0; i< 9; i++) {
					freeTerrains.Add (i);
			}
		}
		for (int i = 0; i < loadingIndexes.Count; i++) {
			newChunkGraphics[loadingIndexes[i]] = chunkGraphics[freeTerrains[i]];
		}
		visibleChunks = newVisibleChunks;
		chunkGraphics = newChunkGraphics;
		for (int i = 0; i < loadingIndexes.Count; i++) {
			loadChunkFromMemory(visibleChunks[loadingIndexes[i]], loadingIndexes[i]);
		
		}
	}
    void loadChunkFromMemory(Vector2 cordIndex, int graphicIndex)
    {
        bool found = false;
        foreach (Vector2 v in loadedChunks)
        {
            if (v == cordIndex)
            {
                found = true;
                break;
            }
        }
        GameObject terrainGO;
        if (!found)
        {
            terrainGO = generateChunk(cordIndex, graphicIndex);
        }
        else
        {
            //Load Chunk from Memory
            Debug.Log("Loading Chunk(" + cordIndex.x + "," + cordIndex.y + ")");
            terrainGO = chunkGraphics[graphicIndex].gameObject;
        }
        terrainGO.transform.position = new Vector3(chunkSizeX * cordIndex.x, 0, chunkSizeY * cordIndex.y);
    }
    GameObject generateChunk(Vector2 cordIndex, int graphicIndex)
    {
        GameObject terrainGO = chunkGraphics[graphicIndex].gameObject;
        loadedChunks.Add(cordIndex);
        setTerrainHeightMap(terrainGO.GetComponent<Terrain>(), cordIndex);
        return terrainGO;
    }
    void setTerrainHeightMap(Terrain terrain, Vector2 cordIndex)
    {
        float[,] heights = new float[terrain.terrainData.heightmapHeight, terrain.terrainData.heightmapWidth];
        bool left = false;
        bool right = false;
        bool top = false;
        bool bottom = false;
        //left
        float[,] hm = getTerrainHeightMap(new Vector2(cordIndex.x - 1, cordIndex.y));
        if(hm != null)
        {
            left = true;
            for (int i = 0; i < hm.GetLength(0); i++)
            {
                heights[i, 0] = hm[i, hm.GetLength(1) - 1];
            }
        }
        //Right
        hm = getTerrainHeightMap(new Vector2(cordIndex.x + 1, cordIndex.y));
        if (hm != null)
        {
            right = true;
            for (int i = 0; i < hm.GetLength(0); i++)
            {
                heights[i, heights.GetLength(1) - 1] = hm[i, 0];
            }
        }
        hm = getTerrainHeightMap(new Vector2(cordIndex.x, cordIndex.y - 1));
        if (hm != null)
        {
            top = true;
            for (int i = 0; i < hm.GetLength(1); i++)
            {
                heights[i, 0] = hm[hm.GetLength(0) - 1, i];
            }
        }
        hm = getTerrainHeightMap(new Vector2(cordIndex.x, cordIndex.y + 1));
        if (hm != null)
        {
            bottom = true;
            for (int i = 0; i < hm.GetLength(0); i++)
            {
                heights[heights.GetLength(1) - 1, i] = hm [0, i];
            }
        }
        if (!top && !left)
        {
            heights[0, 0] = 0.2f;
        }
        if (!bottom && !left)
        {
            heights[terrain.terrainData.heightmapHeight - 1, 0] = 0.2f;
        }
        if (!top && !right)
        {
            heights[0, terrain.terrainData.heightmapWidth - 1] = 0.2f;
        }
        if (!bottom && !right)
        {
            heights[terrain.terrainData.heightmapHeight - 1, terrain.terrainData.heightmapWidth - 1] = 0.2f;
        }
        heights[0, 0] = 0.2f;
        heights[terrain.terrainData.heightmapHeight - 1, 0] = 0.2f;
        heights[0, terrain.terrainData.heightmapWidth - 1] = 0.2f;
        heights[terrain.terrainData.heightmapHeight - 1, terrain.terrainData.heightmapWidth - 1] = 0.2f;
        heights = diamondSquare(heights, 0, 0, terrain.terrainData.heightmapWidth - 1, 0);
        terrain.terrainData.SetHeights(0, 0, heights);
    }
    float[,] getTerrainHeightMap(Vector2 cordIndex)
    {
        if (loadedChunks.Contains(cordIndex))
        {
            for (int i = 0; i < visibleChunks.Length; i++)
            {
                if (visibleChunks[i].x == cordIndex.x && visibleChunks[i].y == cordIndex.y)
                {
                    return chunkGraphics[i].terrainData.GetHeights(0, 0, chunkGraphics[i].terrainData.heightmapWidth, chunkGraphics[i].terrainData.heightmapWidth);
                }
            }
            return loadHeightMapFromMemory(cordIndex);
        }
        else
        {
          return null;
        }
    }
    float[,] loadHeightMapFromMemory(Vector2 cordIndex)
    {
        return null;
    }
    float[,] diamondSquare(float[,] heights, int offSetX, int offSetY, int squareSize, int depth)
    {
        if (squareSize == 1)
            return heights;
        float topLeft = heights[offSetY, offSetX];
        float topRight = heights[offSetY, offSetX + squareSize];
        float bottomLeft = heights[offSetY + squareSize, offSetX];
        float bottomRight = heights[offSetY + squareSize, offSetX + squareSize];
        if (topLeft == 0 || topRight == 0 || bottomLeft == 0 || bottomRight == 0)
        {
            Debug.LogError("One or more Corner Seed Values is not set");
        }
        if (heights[offSetY + (squareSize / 2), offSetX + (squareSize / 2)] == 0)
        {
            heights[offSetY + (squareSize / 2), offSetX + (squareSize / 2)] = getRandomHeight(depth) + averagePoints(topLeft, topRight, bottomLeft, bottomRight);
        }
        float centrePoint = heights[offSetY + (squareSize / 2), offSetX + (squareSize / 2)];
        //left diamond
        float runningAverage = averagePoints(topLeft, centrePoint, bottomLeft);
        if (offSetX - (squareSize / 2) > 0 && heights[offSetY + (squareSize / 2), offSetX - (squareSize / 2)] != 0)
        {
            runningAverage = averagePoints(topLeft, centrePoint, bottomLeft, heights[offSetY + (squareSize / 2), offSetX - (squareSize / 2)]);
        }
        if (heights[offSetY + (squareSize / 2), offSetX] == 0)
        {
            heights[offSetY + (squareSize / 2), offSetX] = runningAverage + getRandomHeight(depth);
        }
        //right diamond
        runningAverage = averagePoints(topRight, centrePoint, bottomRight);
        if (offSetX + (squareSize * 1.5f) < heights.GetLength(1) && heights[offSetY + (squareSize / 2), offSetX + (int)(squareSize * 1.5f)] != 0)
        {
            runningAverage = averagePoints(topRight, centrePoint, bottomRight, heights[offSetY + (squareSize / 2), offSetX + (int)(squareSize * 1.5f)]);
        }
        if (heights[offSetY + (squareSize / 2), offSetX + squareSize] == 0)
        {
            heights[offSetY + (squareSize / 2), offSetX + squareSize] = runningAverage + getRandomHeight(depth);
        }
        //top diamond
        runningAverage = averagePoints(topLeft, centrePoint, topRight);
        if (offSetY - (squareSize / 2) > 0 && heights[offSetY - (squareSize / 2), offSetX + (squareSize / 2)] != 0)
        {
            runningAverage = averagePoints(topLeft, centrePoint, topRight, heights[offSetY - (squareSize / 2), offSetX + (squareSize / 2)]);
        }
        if (heights[offSetY, offSetX + (squareSize / 2)] == 0)
        {
            heights[offSetY, offSetX + (squareSize / 2)] = runningAverage + getRandomHeight(depth);
        }
        //bottom diamond
        runningAverage = averagePoints(bottomRight, centrePoint, bottomLeft);
        if (offSetY + (int)(squareSize * 1.5f) < heights.GetLength(0) && heights[offSetY + (int)(squareSize * 1.5f), offSetX + (squareSize / 2)] != 0)
        {
            runningAverage = averagePoints(bottomRight, centrePoint, topRight, heights[offSetY + (int)(squareSize * 1.5f), offSetX + (squareSize / 2)]);
        }
        if (heights[offSetY + squareSize, offSetX + (squareSize / 2)] == 0)
        {
            heights[offSetY + squareSize, offSetX + (squareSize / 2)] = runningAverage + getRandomHeight(depth);
        }
        heights = diamondSquare(heights, offSetX, offSetY, squareSize / 2, depth + 1);//top left
        heights = diamondSquare(heights, offSetX + (squareSize / 2), offSetY, squareSize / 2, depth + 1);//top right
        heights = diamondSquare(heights, offSetX, offSetY + (squareSize / 2), squareSize / 2, depth + 1);//bottom left
        heights = diamondSquare(heights, offSetX + (squareSize / 2), offSetY + (squareSize / 2), squareSize / 2, depth + 1);//bottom right'
        return heights;
     }
    float averagePoints(float p1, float p2, float p3, float p4)
    {
        return (p1 + p2 + p3 + p4) / 4;
    }
    float averagePoints(float p1, float p2, float p3)
    {
        return (p1 + p2 + p3) / 3;
    }
    float getRandomHeight(int depth)
    {
        return Random.Range(-0.1f, 0.1f) / Mathf.Pow(2, depth);
    }
    void saveChunkToMemory(Terrain chunk, Vector2 index)
    {
        Debug.Log("Unloading Chunk(" + index.x + "," + index.y + ")");
    }
