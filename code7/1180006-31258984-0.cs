    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		List<string> mainList = new List<string> { "blue", "green", "mother", "black", "gray" };
    		List<string> checkList = new List<string> { "mother", "green", "father", "black", "gray" };
    
    		Random r = new Random();
    		
    		// Run five random tests
    		for (int i = 0; i < 5; i++)
    		{
    			string mainListItem = mainList[r.Next(0, mainList.Count)];
    			Console.WriteLine(checkList.Contains(mainListItem)
    							  ? "{0} found in checkList"
    							  : "{0} not found in checkList", mainListItem);
    		}
    	}
    }
