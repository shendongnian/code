    int lineWithParam = 3;
    float factor = 12.32548f;
    
    String[] splittedLine = (file[lineWithParam-1]).Split(new char[] { ' ' }, 2);
    
    if(splittedLine.Length == 2)
    {
    	float par = 0;
    	
    	if(float.TryParse(splittedLine[0], out par))	
    	{
    		file[lineWithParam-1] = (par * factor) + " " + splittedLine[1];
    	}
    }
