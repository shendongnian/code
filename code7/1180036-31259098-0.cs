    Dictionary<int[], string> worldMap = new Dictionary<int[], string>();
    for (int x = 0; x <= 10; x++)
    {
    	for (int y = 0; y <= 10; y++)
    	{
    		int[] cords = new int[] { x, y };
    		worldMap.Add(cords, "empty");
    		Console.WriteLine(worldMap[cords]);
    	}
    }
