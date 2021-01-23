    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    		var str = "    Invisible Pty. Ltd.     1 Nowhere St.  Sydney  2000  AUSTRALIA   ";
    		//str = " A teddy bear   A red firetruck ";
            
    		//tokenize the input delimited by 2 or more whitespaces
            var tokens = Regex.Matches(str, @"\s{2,}|([^\s]+(\s[^\s]+)*)").Cast<Match>().ToArray(); 
    		
    		foreach(var token in tokens)
    		{
    			Console.WriteLine("'{0}' - {1}", token, token.Length);
    	    }
        }
    }
