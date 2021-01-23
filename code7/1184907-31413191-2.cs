    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string[] commands = 
    		{
    			"{AA00:00;|}",
    			"{ABC0:93;||}",
    			"{AAB08:02;|}",
    			"{123AA:AA;|}",
    			"{AA123,123:123,123;|}"
    		};
    		
    		foreach (string command in commands)
    		{
    			if (Regex.Match(command, "^{[A-Z]+\\d+:\\d+;\\|}$").Success)
    			{
    				Console.WriteLine("Good command");
    			}
    			else 
    			{
    				Console.WriteLine("Bad command");
    			}
    		}
    	}
    }
