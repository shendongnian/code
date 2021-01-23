    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    	Regex regex = new Regex(@"[\ ]?help[\ ]?", RegexOptions.IgnoreCase);
    	Match match = regex.Match("Hello, I need help.help.help .");
    	if (match.Success)
    	{
    	    Console.WriteLine(match.Value);
    	}
        }
    }
