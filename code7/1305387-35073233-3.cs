    using System;
    using System.Text.RegularExpressions;
    using System.IO;
    public class Test
    {
    	public static void Main()
    	{
    		Console.WriteLine(IsName("D'Antonio, Patricia"));
    	}
    	public static bool IsName(string input)
    	{
    	     if (string.IsNullOrEmpty(input)) return false;
    	     if (Regex.IsMatch(input, @"^[A-Za-z0-9_']+\s?,\s?[A-Za-z0-9_']+"))
    	     	return true;
    	     else
    	     	return false;
        }
    }
