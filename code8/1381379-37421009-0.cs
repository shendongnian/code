    using System;
    using System.Web;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string encodedText = "Tend&#234;ncias de Desfiles";
    		
    		string decodedText = HttpUtility.HtmlDecode(encodedText);
    		
    		Console.WriteLine(decodedText);
    	}
    }
