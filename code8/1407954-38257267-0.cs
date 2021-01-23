    for (int row = 0; row < 10; row++)
    {
    	// This code will only get run for the first 3 rows
    	for (int column = 0; column + row < 4; column++)
    	{
    		Console.Write(" ");
    	}
    
    	// This code will only get run for rows 4 and greater
    	for (int column = 0; column + row >= 4; column++)
    	{
    		if (column - row >= 5)
    			break;
    		Console.Write("*");
    	}
    	Console.WriteLine();
    }
