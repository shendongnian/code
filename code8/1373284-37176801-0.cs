    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string input = "(Service=[CarSales]&(Type=[News]|Type=[Review]))";
    
            string pattern = @"Type=\[(\w*)\]";
    
            MatchCollection matches = Regex.Matches(input, pattern);
    		
    		
            foreach(Match match in matches)
            {
    			Console.WriteLine(match.Groups[1].Value);
            }
    		
    		
    	}
    } 
