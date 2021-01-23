    public Dictionary<WorldMapCoord, string> worldMap = new Dictionary<WorldMapCoord, string>();
	for (int x=0; x <= 10; x++)
	{
    	for (int y=0; y <= 10; y++)
		{
        	worldMap.Add(new WorldMapCoord(x, y), "empty");          
    	}
	}
