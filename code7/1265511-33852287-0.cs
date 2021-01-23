    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		var input = "\n\nHi\n\n\nTest\nTest";
    		
    		var matches = Regex.Matches(input, "\\n");
    
    		for (int index = 0; index < matches.Count - 1; index++)
    		{
    			var match = matches[index];
    			
    			if (match.Index + 1 != matches[index + 1].Index)
    			{
    				Console.WriteLine("Last Match found at " + match.Index);
    				Console.WriteLine("Next first Match found after last item at " + matches[index + 1].Index);
    			}
    		}
    		
    		Console.WriteLine("Last Match found at " + matches[matches.Count - 1].Index);
    	}
    }
