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
    		Dictionary<string, CompassDirection> newDictionary1 = dictionary
    			.Where(entry => entry.Value.HasValue)
    			.ToDictionary(e => e.Key, e => e.Value.Value);
    		newDictionary1.Keys.ToList().ForEach(key => Console.WriteLine("Key: {0} Value: {1}", key, dictionary[key]));
    		Console.WriteLine();
    
    		Console.WriteLine("New Dictionary 2:");		
    		Dictionary<string, CompassDirection> newDictionary2 = new Dictionary<string, CompassDirection>();
    		foreach (String key in dictionary.Keys)
    		{
    			if (dictionary[key].HasValue)
    			{
    				newDictionary2.Add(key, dictionary[key].Value);
    			}
    		}
    		newDictionary2.Keys.ToList().ForEach(key => Console.WriteLine("Key: {0} Value: {1}", key, dictionary[key]));
    	}
    }
    
    public enum CompassDirection
    {
        North, East, South, West
    }
