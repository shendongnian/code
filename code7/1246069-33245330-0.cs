    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var text = "200,001 ,-"; 
    		
    		var regex = new Regex(@"\d\d*,\d\d*");
    		foreach(var match in regex.Matches(text))
    		{
    			Console.WriteLine(match.ToString());
    		}
    		
    	}
    }
