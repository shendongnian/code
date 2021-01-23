    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var vectors = new List<string>();
    		vectors.Add("1 0 0 0 1 1 1 0 0 0 1 0 1 1 0 0 0 0 1 0 0 1"); 
            vectors.Add("1 0 0 0 0 1 1 0 0 0 1 0 0 1 0 0 0 0 0 0 0 1");
    		
    		
    		foreach(var v in vectors)
    		{
    			var result = new List<string>();
    			int max = 0;
    			foreach(var c in v)
    			{
    				if(string.IsNullOrEmpty(c.ToString().Trim())) continue;
    				//Console.Write(c);
    				//Console.Write(max);
    				if(c != '1')
    				{
    					max = 0;
    				}
    				else
    				{
    					max++;
    					if(max > result.Count)
    					{
    						result.Add(c.ToString());
    					}
    				}
    			}
    			
    			Console.WriteLine("Final Result: " + string.Join(" ", result));
    		}
    	}
    }
