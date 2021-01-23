    using (StreamReader readInputFile = new StreamReader(inputFile))
    {
    
    	string line;
    	bool isPoint = false;
    	bool isCoord = false;
    	Regex pointRegex = new Regex("point\\s+\\[");
    	Regex coordRegex = new Regex("coordIndex\\s+\\[");
    	Regex endBrace = new Regex("\\s*\\]\\s*");
    	
    	while ((line = readInputFile.ReadLine()) != null)
    	{
    		if (!string.IsNullOrWhiteSpace(line))
    		{
    			//Remove tabs
    			string line_noTabs = line.Replace("\t", "");
    			if(pointRegex.IsMatch(line_noTabs))
    			{
    				isPoint = true;
    				continue;
    			}
    			else if(coordRegex.IsMatch(line_noTabs))
    			{
    				isCoord = true;
    				continue;
    			}
    			else if (endBrace.IsMatch(line_noTabs))
    			{
    				isPoint = false;	//Reset
    				isCoord = false;  	//Reset
    				continue;
    			}
    			
    			if(isPoint)
    				points.Add(line_noTabs);
    			else if(isCoord)
    				coords.Add(line_noTabs);
    		}
    	}
    }
