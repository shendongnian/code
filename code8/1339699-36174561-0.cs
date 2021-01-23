    using System;
    using System.Text.RegularExpressions;
     
    public class Test
    {
    	public static void Main()
    	{
          String text = "/green/blah/agriculture/apple/blah/hallo/apple/green/blah/agriculture/apple/blah/hallo/apple";
    	  var regex = new Regex(Regex.Escape("apple"));
          String replacement = "Orange";
          string result = regex.Replace(text, replacement.ToString(), 1);
          Console.WriteLine(result);
    	}
    }
