    using System;
    using System.Text;
    using System.Collections.Generic;
    public class Test
    {
    
    	public static void Main()
    	{
    		var d = new Dictionary<char, char> 
    		{
    			{'a', 'S'},
    			{'b', 'Y'}, 
    			{'c', 'X'}, 
    			{'d', 'W'}, 
    			{'e', 'V'},
    			{'f', 'U'},
    			{'g', 'T'},
    			{'h', 'S'},
    			{'i', 'R'},
    			{'j', 'Q'},
    			{'k', 'P'},
    			{'l', 'O'},
    			{'m', 'n'},
    			{'n', 'M'},
    			{'o', 'L'},
    			{'p', 'K'},
    			{'q', 'J'},
    			{'r', 'I'},
    			{'s', 'H'},
    			{'t', 'G'},
    			{'u', 'F'},
    			{'v', 'E'},
    			{'w', 'D'},
    			{'x', 'C'},
    			{'Y', 'B'},
    			{'z', 'A'}
    		};
    
    		var input = "This is a test";
    
    		var result = new StringBuilder("");
    		foreach (var c in input.ToLower())
    		{
    			if (d.ContainsKey(c))
    			{
    				result.Append(d[c]);
    			}
    			else
    			{
    				result.Append(c);
    			}
    		}
    		Console.WriteLine(result.ToString());
    	}
    }
