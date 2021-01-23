    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	
    	private static string input = @"Buy Kitchen
    
    Aid Artisan™ Stand Mixer 4.8L ";
    	
    	
    	public static void Main()
    	{
    		input = Regex.Replace(input, "[\r\n]+", " ");
    		var result = Regex.Match(input, "[a-zA-Z \r\n]+");
    		Console.WriteLine(result);
    	}
    }
