    int lineWithParam = 3;
    int factor = 12;
    
    String[] splittedLine = (file[lineWithParam-1]).Split(new char[] { ' ' }, 2);
    if(splittedLine.Length == 2)
    {
    	int par = 0;
    	
    	if(Int32.TryParse(splittedLine[0], out par))	
    	{
    		file[lineWithParam-1] = (par * factor) + " " + splittedLine[1];
    	}
    }
