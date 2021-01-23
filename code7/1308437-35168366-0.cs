    int[] numbers = new int[4];
    
    for (int i = 0; i < 4; i++)
    {
    	Console.WriteLine("Enter a number: ");
    	string c = Console.ReadLine();
    	int value;
    	if (int.TryParse(c, out value))
    	{
    		numbers[i] = value;
    	}
    	else
    	{
    		i--;
    		Console.WriteLine("You did not enter a number\n");
    	}
    }
    
    for (int i = 0; i < numbers.Length; i++ )
    {
    	Console.Write(numbers[i] + " ");
    }
