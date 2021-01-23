    using System;
    using System.Globalization;
    using System.Linq;
    using System.Collections.Generic;
    public class Test
    {
    	public static void Main()
    	{
    		
    		var InputMonths = new List<string> { "January","march","sepTEmber","smarch" };
    
    		var MonthNames = new DateTimeFormatInfo().MonthNames.ToList();
    		
    		var InputMonthNumbers = new List<int>();
    		
    		foreach (var m in InputMonths)
    		{
    			//Find index of the month name, ignoring case
    			//Note if the input month name is invalid, FindIndex will return 0
    			int month_num = 1 + MonthNames.FindIndex(name => name.Equals(m, StringComparison.OrdinalIgnoreCase));
    
    			if (month_num > 0)
    			{
    				InputMonthNumbers.Add(month_num);
    			}
    		}
    		
    		foreach (var n in InputMonthNumbers)
    		{
    			Console.WriteLine(n.ToString());
    		}
    		
    	}
    }
