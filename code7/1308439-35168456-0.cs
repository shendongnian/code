     int[] numbers = new int[4];
    		
    		
    	int i = 0;
    	do
    	{
    	   Console.WriteLine("Enter a number: ");
    		 string c = Console.ReadLine();
                int value;
                if (int.TryParse(c, out value))
                {
                    numbers[i] = value;
    				i++;
                }
    		 else
                {
                    Console.WriteLine("You did not enter a number\n");
                }
    	    
    	} while (i < 5);
    		
        Console.WriteLine("\nYour entered numbers are\n");
             for (int j = 0; j < numbers.Length; j++ )
            {
                Console.Write(numbers[j] + " ");
            }
