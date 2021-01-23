    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string input = @"(Project in (""CI"") and Status in (""Open"") and issueType in (""Action Item"")) or issueKey = ""GR L-1"" order by Created asc";
    		
    		// Find the open paren & quote
    		int startIndex = input.IndexOf("(\"", 0);
    		
    		// Loop until we don't find an open paren & quote
    		while (startIndex > -1)
    		{
    			// Find the closing paren & quote
    			int endIndex = input.IndexOf("\")", startIndex);
    			
    			Console.WriteLine(input.Substring(startIndex + 2, endIndex - startIndex - 2));
    			
    			// Find the next open paren & quote
    			startIndex = input.IndexOf("(\"", endIndex);
    		}
    	}
    }
