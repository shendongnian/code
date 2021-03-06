    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		// an example of input
    		var input = "YH300s, H900H, 234, 90.5, +12D, 48E, R180S, 190A, 350A, J380S";
    		
    		var parts = input.Split(new[]{", "}, StringSplitOptions.RemoveEmptyEntries);
            // regex for 3+ digit numbers
    		var regex = new Regex(@"\d\d\d+");
    		
    		foreach(var part in parts)
    		{
                // there can be many matches, e.g. "A100B1111" => "100" and "1111"            
    			foreach(Match m in regex.Matches(part))
    			{
    				if (int.Parse(m.Value) > 125)
    				{
    					Console.WriteLine(part);
    					break;
    				}
    			}					
    		}    		
    	}
    }
