    string ConvertDashToCamelCase(string input)
    {
        StringBuilder sb = new StringBuilder();
        bool caseFlag = false;
    	bool startTagFlag = true; // Implies that the input (XML string) must begin with a '<' character
    	bool endTagFlag = false;
        for (int i = 0; i < input.Length; ++i)
        {
            char c = input[i];
    		
    		if(startTagFlag && !endTagFlag)
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
    		
    		// Reset tag flags if necessary
    		if(c == '>' || c == '<')
    		{
    			startTagFlag = (c == '<');
    			endTagFlag = (c == '>');
    		}
    		
        }
        return sb.ToString();
    }
