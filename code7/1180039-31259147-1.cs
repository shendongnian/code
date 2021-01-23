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
    				worldMap.Add(cords, String.Format("empty{0}_{1}", x, y));
    			}
    		}
    		// This should have 121 coordinates from (0, 0) to (10, 10)
    		List<int[]> coords = worldMap.Keys.ToList();
    		Console.WriteLine(worldMap[coords[21]]);
    	}
    }
