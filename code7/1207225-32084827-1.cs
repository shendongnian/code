    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var regex = new Regex(".*?<div id=\"13\">");
    		var test = "<html xmlns=\"http://www.w3.org/1999/xhtml\"><head runat=\"server\"><title></title></head><body><table> <tr><td>test</td></tr> </table><div id=\"13\"> </body> test test test test </html>";
    		var match = regex.Match(test);
    		if (match.Success)
    		{
    			Console.WriteLine("Found!");
    			Console.WriteLine(match.Value);
    		}
    		else
    		{
    			Console.WriteLine("Not Found!");
    		}
    		Console.ReadLine();			
    	}
    }
