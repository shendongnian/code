    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Test
    {
    	public static void Main()
    	{
    		var dict = new Dictionary<int, string>
    		{
    			{ 0, "Foo"}
    		};
    		
    		foreach (var kvp in dict.ToList())
    		{
    			dict[kvp.Key] = "Bar";
    			
    			Console.WriteLine(kvp.Value); // Foo (the initial value)
    			Console.WriteLine(dict[kvp.Key]); // Bar (the value that was set)
    		}
    	}
    }
