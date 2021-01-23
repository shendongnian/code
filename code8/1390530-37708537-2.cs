    List<string> allLines = new List<string>();
    	using (StreamReader reader = new StreamReader(stream))
    	{
    	    string line;
    	    while ((line = reader.ReadLine()) != null)
    	    {
    		allLines.Add(line); // Add to list.    	
    	    }
    	}
