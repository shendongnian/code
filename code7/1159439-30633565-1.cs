    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		String text = "[Testing.User]|Info:([Testing.Info]|Name:([System.String]|Matt)|Age:([System.Int32]|21))|Description:([System.String]|This is some description)";
    		String pattern = "(\\[\\w+\\.\\w+\\])\\|(\\w+:.+)\\|(\\w+:.+)";
    		
    		Match match = Regex.Match(text, pattern);
    		if (match.Success)
    		{
    			Console.WriteLine(match.Groups[1]);
    			Console.WriteLine(match.Groups[2]);
    			Console.WriteLine(match.Groups[3]);	
    		}
    	}
    }
