    using System;
    
    class Programm
    {
    	static void Main()
    	{
    		var answer = "Please help me with this puzzle please"; 
    		var words = new[] { "Please", "help", "me", "with", "this", "puzzle", "please" };
    
    		var result = "";
    		var wordCount = 0;
    
    		for (var iCount = 12; iCount > 0; iCount--)
    		{
    			while (wordCount < 4) //less than because word count get's incremented
    			{
    				if (iCount % 1 == 0)
    				{
    					result += words[wordCount]; 
    					result += " ";
    					wordCount++;
    				}
    
    				if ((iCount * 6) == 24)
    				{
    					result += words[wordCount]; 
    					result += " ";
    					wordCount++;
    				}
    				iCount--;
    			}
    
    			if (iCount % 3 != 1)
    				continue;
    
    			result += words[wordCount]; 
    
    			if (wordCount != 6)
    				result += " ";
    
    			wordCount += 1;
    		}
    
    		Console.WriteLine("Result: " + result);
    		
    		if ( result == answer )
    			Console.WriteLine("Correct!");
    		else
    			Console.WriteLine("FAIL!");
    	}
    }
