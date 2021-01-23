    //finds the sum of all values
    public int SumArray(int[,] array)
    {
        int total = 0;
        // Iterate through the first dimension of the array
        for (int i = 0; i < array.GetLength(0); i++)
    	{
            // Iterate through the second dimension
    	    for (int j = 0; j < array.GetLength(1); j++)
    	    {
                // Add the value at this location to the total
                // (+= is shorthand for saying total = total + <something>)
    	        total += array[i, j];
    	    }
    	}
    	return total;
    }
