    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		Dictionary<int[], string> worldMap = new Dictionary<int[], string>();
    		for (int x = 0; x <= 10; x++)
    		{
    			for (int y = 0; y <= 10; y++)
    			{
    				int[] cords = new int[] { x, y };
                    // Every value will be "empty"
    				worldMap.Add(cords, "empty");
    			}
    		}
    		List<int[]> coords = worldMap.Keys.ToList();
    		Console.WriteLine(worldMap[coords[0]]);
    	}
    }
