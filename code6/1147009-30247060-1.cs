    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	private static Dictionary<String, Tile> tiles = 
            new Dictionary<String, Tile>();
    	public static void Main()
    	{
    		tiles.Add("x", new Tile { Name = "y" });
    		var value = tiles["x"];
    		Console.WriteLine(value.Name);
    	}
    	
    	public class Tile
    	{
    		public string Name { get; set; }
    	}
    }
