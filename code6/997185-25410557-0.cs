    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    		    var rowPattern = new Regex(@"(?<row>\[[^]]+\])", RegexOptions.Multiline | RegexOptions.ExplicitCapture);
    			var columnPattern = new Regex(@"(?<column>\"".+?\"")", RegexOptions.Multiline | RegexOptions.ExplicitCapture);
    		    var data = "[\"Id\",\"Username\",\"Cash\",\"Password\"],[\"Id\",\"Username\",\"Cash\",\"Password\"]";
    		    var rows = rowPattern.Matches(data);
    			var rowCounter = 0;
    			foreach (var row in rows)
    			{
    				Console.WriteLine("Row #{0}", ++rowCounter);
    				var columns = columnPattern.Matches(row.ToString());
    				foreach (var column in columns)
    					Console.WriteLine("\t{0}", column);
    			}
    			Console.ReadLine();
    		}
    	}
    }
