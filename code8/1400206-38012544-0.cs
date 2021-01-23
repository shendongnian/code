    Console.WriteLine("The highest average grade is {0}.", maxAvg);
    
    Console.WriteLine("The students with this average grade are");
    		for (int i = 0; i < stuCount; i++)
    		{
    			if (avg[i] == maxAvg)
    			{
    				 Console.WriteLine(name[i]);
    			}
    		}
