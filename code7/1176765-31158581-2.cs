    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
	public static void Main()
	{
		
		string pattern = "(Mon|Tue|Wed|Thu|Fri|Sat|Sun)";
		
		string[] values = {"Mon","Tue","Wed","Thu","Fri","Sat","Sun","Bun","Boo","Moo"};
		
		Console.WriteLine("");
		
		
		foreach(var val in values){
			
			Console.WriteLine("{0} ? {1}",val,Regex.IsMatch(val,pattern));
			
		}
    	}
    }
