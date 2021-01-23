    using System;
    using System.Text.RegularExpressions;
    	
    public class Program
    {
    	public static void Main()
    	{
    		string str = "Hello!I'm new here and this is my first question.";
    		string str2 = "Hello Im new here.";
    		
    		string tempStr = Regex.Replace(str, "\\W+", "");
    		string tempStr2 = Regex.Replace(str2, "\\W+", "");
    		
    		int startIndex = tempStr.IndexOf(tempStr2);
    		Console.WriteLine(tempStr);
    		Console.WriteLine(tempStr2);
    		Console.WriteLine("Index of str2 starts a {0} ", startIndex);
    	}
    }
