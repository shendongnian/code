    string innerString = "Clicking Log Out will clear our cookies and log you out of Stack Overflow on all devices";
    if (innerString.Length > 37)
    {
    	int startvalue = 38;
    	while (startvalue < innerString.Length)
    	{
    		if (innerString[startvalue] == ' ')
    		{
    			innerString = innerString.Insert(startvalue, System.Environment.NewLine).TrimEnd();
    			startvalue = startvalue + 38;
    		}
    		else
    		{
    			int i = innerString.LastIndexOf(" ", startvalue);
    			startvalue = i++;
    			innerString = innerString.Insert(startvalue, System.Environment.NewLine).TrimEnd();
    			startvalue = startvalue + 38;
    		}
    	}
    }
