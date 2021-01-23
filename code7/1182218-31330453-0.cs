    // See if we can parse the 'text' string.
    	// If we can't, TryParse will return false.
    	// Note the "out" keyword in TryParse.
    	string text1 = "x";
    	int num1;
    	bool res = int.TryParse(text1, out num1);
    	if (res == false)
    	{
    	    // String is not a number.
    	}
    
    	// Use int.TryParse on a valid numeric string.
    	string text2 = "10000";
    	int num2;
    	if (int.TryParse(text2, out num2))
    	{
    	    // It was assigned.
    	}
