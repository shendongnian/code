    using System;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		string stringToParse = "Category A|Category A > Sub Category 1|Category B|Category C|Category C > Sub Category 2";
    		var parts = stringToParse.Split('|').GroupBy(part => part.Split('>').Select(innerPart => innerPart.Trim()).FirstOrDefault()).Select(part => part.Max());
    		
    		foreach(var part in parts)
    			Console.WriteLine(part);
    	}
    }
