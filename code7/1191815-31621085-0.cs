    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		int expectedNumberOfTabs = 5;
    		
    		List<string> rows = new List<string>
    		{
    			"col1 \t col2 \t col3 \t col4 \t col5 \t col6",
    			"col1 \t col2 \t col3 \t col4 \t col5 \t col6",
    			"col1 \t col2 \t col3 \t col4",
    			"col1 \t col2 \t col3 \t col4 \t col5 \t col6 \t col7",
    			"col1 \t col2 \t col3 \t col4 \t col5 \t col6",
    			"col1 \t col2 \t col3 \t col4 \t col5",
    			"col1 \t col2 \t col3 \t col4 \t col5 \t col6",
    		};
    
    		var badRows = rows.Where(row => row.Count(c => c == '\t') != expectedNumberOfTabs);
    		foreach (var badRow in badRows)
    		{
                // Fix the bad rows
    			Console.WriteLine(badRow);
    		}
    	}
    }
