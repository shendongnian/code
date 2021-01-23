    public string InsertSpaceBeforeUpperCAse(string input)
    {	
    	var result = "";	
    
    	foreach (char c in input)
    	{
    		if (char.IsUpper(c))
    		{
    			// if not the first letter, insert space before uppercase
    			if (!string.IsNullOrEmpty(result))
    			{
    				result += " ";
    			}			
    		}
    		// start new word
    		result += c;
    	}
    	
    	return result;
    }
