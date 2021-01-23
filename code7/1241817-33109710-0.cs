    using System;
    using System.Collections.Generic;				
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var test = "1 2 3 x";
    		var values = test.Split(' ');
    		var results = new List<int>();
    		foreach(var value in values)
    		{
    			int x;
    			if(Int32.TryParse(value, out x))
    			{
    			   results.Add(x);
    			}
    			else
    			{ 
    				Console.WriteLine("{0} is not an integer", value);
    			}
    		}
    	}
    }
