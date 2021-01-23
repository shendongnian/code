    /* String for combos to be enumerated */
    char[] set = { 'a', 'b', 'c', 'd' };
    /* Length of the array */
    int setLength = set.Length, a, b, c;
    
    /* This will print all combos that have 1 value. E.g. A, B, C, D */
    for (a = 0; a < setLength; a++)	
	{
        Console.WriteLine(set[a] + Environment.NewLine);
	}
    
    /* This will give the 1st value of the combo */
    for (a = 0; a < setLength; a++)
	{
		/* This will give the 2nd value. Resulting in combos with a length of 2 */
		for (b = 0; b < setLength; b++)			
		{
            Console.WriteLine(set[a] + set[b] + Environment.NewLine);
		}
	}
    
    /* 1st value */
	for (a = 0; a < setLength; a++)
	{
		/* 2nd value */
		for (b = 0; b < setLength; b++)
		{
			/* 3rd value */
			for (c = 0; c < setLength; c++)
			{
                Console.WriteLine(set[a] + set[b] + set[c] + Environment.NewLine);
			}
		}
	}
	/* To continue with longer combos simply add more and more for loops */
