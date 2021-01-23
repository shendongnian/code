    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string fileContent = "    For fine-grained control over your PC�s power settings, click the\n" +
    			"<p>    �Change plan settings� link next to the power plan you�ve... </p>";
    		
    		fileContent = Regex.Replace(fileContent, "[^\\w\\s\\p{P}\\p{Sm}<>]+", String.Empty);
    		Console.WriteLine(fileContent);
    	}
    }
