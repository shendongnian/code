    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{ 
            // dummy ini for testing.
    		var ini = "test\nfileExecutable=D:\\location\ntest";
			
			var regex = new Regex("^fileExecutable=(.+)$", RegexOptions.Multiline);
			var location = regex.Match(ini).Groups[1];
			
    		Console.WriteLine(location);
    	}
    }
