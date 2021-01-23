    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		string s = "nika ?+ marry = love+sandra ?+ alex = love";
    		string[] result = Regex.Split(s, "\\?{0}\\+", RegexOptions.Multiline);      			
    		s = String.Join("\n", result);		
    		Regex rgx = new Regex("\\?\\n");
          	s = rgx.Replace(s, "+");
    		result = Regex.Split(s, "\\n", RegexOptions.Multiline);      					
    		foreach (string match in result)
          	{
    	         Console.WriteLine("'{0}'", match);
        	}	
    	}
    }
