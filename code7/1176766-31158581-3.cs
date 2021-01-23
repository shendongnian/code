        using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		var matches = new HashSet<String>(System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.AbbreviatedDayNames,StringComparer.OrdinalIgnoreCase);
    		
    		string[] values = {"Mon","Tue","Wed","Thu","Fri","Sat","Sun","Bun","Boo","Moo","Foo","Bar"};
    		
    		
    		foreach(var val in values){
    			
    			Console.WriteLine("{0} ? {1}", val, matches.Contains(val));
    			
    		}
    	}
    }
