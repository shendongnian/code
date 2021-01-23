    string filter = sometextbox.Text;
    if(RegexCheckBox.IsChecked)
    {
    	Regex rgx = new Regex(filter);
    	for (int i = 0; i < data.Count; i++)
    	{
        	if (rgx.IsMatch(data[i].Content))
        	{
            	// Found it, preset it to the user
            	break;
        	}
    	}	
    }
    else
    {
    	for (int i = 0; i < data.Count; i++)
    	{
    		if(data[i] == filter)
    		{
    			//found it, present it to the user
    			break;
    		}
    	}
    }
