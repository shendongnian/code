    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    					
    public class Program
    {   	
    	private static string input = @"Buy Kitchen
    
    Aid Artisan™ Stand Mixer 4.8L ";
   
    	public static void Main()
    	{
    		var match = Regex
    			.Match(input, @"[a-zA-Z0-9\p{P}]+");
    		
    		StringBuilder builder = new StringBuilder();
    		while(match.Success)
    		{
    			builder.Append(match + " ");
    			match = match.NextMatch();
    		}
    		Console.WriteLine(builder.ToString());
    	}
    }
