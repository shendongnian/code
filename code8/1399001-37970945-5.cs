    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
			String test = "this is a @test & when ist asd*sd";
			
			if (Regex.Match(test, "([@&\\*])").Success) 
			{
				Console.WriteLine("%, & or * found!");
			}
			else
			{
				Console.WriteLine("Not found!");
			}
    	}
    }
