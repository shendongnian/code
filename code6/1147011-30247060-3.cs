    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	private static Dictionary<String, Tile> tiles = new Dictionary<String, Tile>();
    	public static void Main()
    	{
    		// add two items to the dictionary
    		tiles.Add("x", new Tile { Name = "y" });
    		tiles.Add("x:null", null);
    		
    		// indexer access
    		var value1 = tiles["x"];
    		Console.WriteLine(value1.Name);
    		
    		// TryGetValue access
    		Tile value2;
    		tiles.TryGetValue("x", out value2);
    		Console.WriteLine(value2.Name);
    		
    		// indexer access of a null value
            var value3 = tiles["x:null"];
    		Console.WriteLine(value3 == null);
    		
    		// TryGetValue access with a null value
    		Tile value4;
    		tiles.TryGetValue("x:null", out value4);
    		Console.WriteLine(value4 == null);
    		
    		// indexer access with the key not present
    		try
    		{
    	        var n1 = tiles["nope"];		
    		}
    		catch(KeyNotFoundException e)
    		{
    			Console.WriteLine(e.Message);
    		}
    
    		// TryGetValue access with the key not present		
    		Tile n2;
    		var result = tiles.TryGetValue("nope", out n2);
    		Console.WriteLine(result);
    		Console.WriteLine(n2 == null);
    	}
    	
    	public class Tile
    	{
    		public string Name { get; set; }
    	}
    }
