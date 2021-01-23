    public bool IsSamePhone
    {
    	get
    	{
    		return IsSamePhoneNumbers(); 
    	}
    	// This bad set code was the cause of the 502.3 Gateway Error.  
    	// The error disappeared once this was commented out.
    	//set
    	//{
    	//	IsSamePhone = value;
    	//}
    } 
