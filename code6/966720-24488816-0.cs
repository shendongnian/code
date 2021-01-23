    for	(int i= 7; i>=0; i--)
    		{
    			if (i == 1)
    			{
    				Console.WriteLine(new string('C', i));
    			}
    			else
    			{
    				Console.WriteLine(new string('*', i));
    			}
    		}
    		
    		for (int j = 1; j<9; j++)
    		{  
    			if (j == 7)
    			{
    				Console.WriteLine(new string('0', j));
    			}
    			else
    			{
    				Console.WriteLine(new string('*', j));
    			}
    		}
