    using System;
    using System.Text.RegularExpressions;
    public class Test
    {
	  public static void Main()
	  {
		String text = "/green/blah/agriculture/apple/blah/hallo/apple";
		var regex =  new Regex("^(/(?:green|red)/(?:[^/]+/)*?)apple(/.*)");
		String replacement = "$1$2Orange$4";
		string result = Regex.Replace(text, regex.ToString(), replacement);
      	Console.WriteLine(result);
	  }
    }
