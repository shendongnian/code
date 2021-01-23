        List<string> stringlist = new List<string>();
        string userinput = null;
    
        while (userinput != "end")
        {
    	userinput = getstring();
    
    	// Check for Substrings
    	foreach (string s in stringlist.Where(s => s.Contains(userinput)))
    	{
    		Console.WriteLine("{0} is a substring of {1}", userinput, s);
    	}
    
    	// Add to the list
    	if (stringlist.Contains(userinput))
    	{
    		Console.WriteLine(" Term has been stored previously.");
    	}
    	else
    	{
    		stringlist.Add(userinput);
    	}
        } // end of main while loop
