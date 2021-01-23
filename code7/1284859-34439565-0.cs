    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var str = @"<p id=""abc""></p>
    <p id=""cde"">Text<br/>More text</p>";
    		Console.WriteLine(Regex.Replace(str, @"<p.*?><\/p>", ""));
    	}
    }
