    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main(string[] args)
    	{
    		var dictionary = new Dictionary<string, CompassDirection?>
    		{
    			{ "Foo", CompassDirection.North },
    			{ "Bar", null },
    			{ "Baz", CompassDirection.West }
    		};
    		
    		Console.WriteLine("New Dictionary 1:");
    		PrintDictionary(RemoveNullMethod1(dictionary));
    
    		Console.WriteLine("New Dictionary 2:");		
    		PrintDictionary(RemoveNullMethod2(dictionary));
    	}
    	
    	public static Dictionary<string, CompassDirection> RemoveNullMethod1(Dictionary<string, CompassDirection?> input)
    	{
    		return input
    			.Where(entry => entry.Value.HasValue)
    			.ToDictionary(e => e.Key, e => e.Value.Value);
    	}
    	
    	public static Dictionary<string, CompassDirection> RemoveNullMethod2(Dictionary<string, CompassDirection?> input)
    	{
    		Dictionary<string, CompassDirection> newDictionary = new Dictionary<string, CompassDirection>();
    		foreach(KeyValuePair<string, CompassDirection?> entry in input)
    		{
    			if (entry.Value.HasValue)
    			{
    				newDictionary.Add(entry.Key, entry.Value.Value);
    			}
    		}
    		return newDictionary;
    	}
    	
    	public static void PrintDictionary(Dictionary<string, CompassDirection> input)
    	{
    		foreach(KeyValuePair<string, CompassDirection> entry in input)
    		{
    			Console.WriteLine("Key: {0} Value: {1}", entry.Key, entry.Value);
    		}
    		Console.WriteLine();
    	}
    }
    
    public enum CompassDirection
    {
        North, East, South, West
    }
