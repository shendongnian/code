    int lineWithParam = 3;
    
    String[] splittedLine = (file[lineWithParam-1]).Split(new char[] { ' ' }, 2);
    
    if(splittedLine.Length == 2)
    {
    	float fact = 0.0f;
    	
    	String newFact = splittedLine[0];
    	
    	// or how ever you want to modify your factor
    	if(float.TryParse(splittedLine[0], out fact))	
    	{
    		newFact = "" + (fact * 12.3f);
    		
    	}
    	
    	file[lineWithParam-1] = newFact + " " + splittedLine[1];
    }
