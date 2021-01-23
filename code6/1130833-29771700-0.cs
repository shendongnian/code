    private void Calculate(string[] lines)
    {
    	try
    	{
    		lines.ForEach(Validate);
    		
    		// process lines
    	}
    	catch(InvalidArgumentException ex)
    	{
    	    MessageBox.Show(...);
    	}	
    }
    
    private void Validate(string s)
    {
    	if(s.IsNullOrEmpty)
    		throw new InvalidArgumentException(/* some details here*/);
    }
