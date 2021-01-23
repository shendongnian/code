    public static string GetNewFileExtension(string[] fileNames) 
    {
    	int maxIndex = 0;
    	
    	foreach (var fileName in fileNames)
    	{
    		// get the file extension and remove the "."
    		string extension = Path.GetExtension(fileName).Substring(1); 
    		int parsedIndex;
    		// try to parse the file index and do a one pass max element search
    		if(int.TryParse(extension, out parsedIndex)) 
    		{
    			if(parsedIndex > maxIndex)
    			{
    				maxIndex = parsedIndex;
    			}
    		}
    	}
    	
    	// increment max index by 1
    	return string.Format(".{0}", maxIndex + 1); 
    }
