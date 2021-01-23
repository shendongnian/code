    string ConvertDashToCamelCase(string input)
    {
        StringBuilder sb = new StringBuilder();
        bool caseFlag = false;
    	bool tagFlag = false; 
    	for(int i = 0; i < input.Length; i++)
        {	
    		char c = input[i];
    		if(tagFlag)
    		{
    			if (c == '-')
    			{
    				caseFlag = true;
    			}
    			else if (caseFlag)
    			{
    				sb.Append(char.ToUpper(c));
    				caseFlag = false;
    			}
    			else
    			{
    				sb.Append(char.ToLower(c));
    			}
    		}
    		else
    		{
    			sb.Append(c);
    		}
    		
    		// Reset tag flag if necessary
    		if(c == '>' || c == '<')
    		{
    			tagFlag = (c == '<');
    		}
    		
        }
        return sb.ToString();
    }
