    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List <string> mylist=new List <string>();
    		mylist.Add("%1");
    		mylist.Add("%136%250%3"); 			 
    		mylist.Add("%1%5%20%1%10%50%8%3");   
    		mylist.Add("%4%255%20%1%14%50%8%4"); 
    		
    		// Determine what character appears most in a single string in the list
    		char maxCharacter = ' ';
    		int maxCount = 0;
    		foreach (string item in mylist)
    		{
    			// Get the max occurrence of each character
    			int max = item.Max(m => item.Count(c => c == m));
    			if (max > maxCount)
    			{
    				maxCount = max;
    				// Store the character whose occurrence equals the max
    				maxCharacter = item.Select(c => c).Where(c => item.Count(i => i == c) == max).First();
    			}
    		}
    		
    		// Print the strings containing the max character
    		mylist.Where(item => item.Count(c => c == maxCharacter) == maxCount)
    			.ToList().ForEach(Console.WriteLine);
    	}
    }
