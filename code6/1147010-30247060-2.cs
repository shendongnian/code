    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	private static Dictionary<String, Tile> tiles = 
            new Dictionary<String, Tile>();
    	public static void Main()
    	{
    		tiles.Add("x", new Tile { Name = "y" });
    		var value1 = tiles["x"];
    		Console.WriteLine(value1.Name);
    		
    		Tile value2;
    		tiles.TryGetValue("x", out value2);
    		Console.WriteLine(value2.Name);
    	}
    	
    	public class Tile
    	{
    		public string Name { get; set; }
    	}
    }
