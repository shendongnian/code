    List<string> list = new List<string>();
    	using (StreamReader reader = new StreamReader(stream))
    	{
    	    string line;
    	    while ((line = reader.ReadLine()) != null)
    	    {
    		list.Add(line); // Add to list.    	
    	    }
    	}
