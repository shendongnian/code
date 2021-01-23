    private string _prop1;
    private int _prop2;
    
    public string Prop1
    {
    	get
    	{
    		return _prop1;
    	}
    	set
    	{
    		_prop1 = value;
    		RiseEvent(nameof(Prop1),Prop1);
    	}
    }
    
    public int Prop2
    {
    	get
    	{
    		return _prop2;
    	}
    	set
    	{
    		_prop2 = value;
    		RiseEvent(nameof(Prop2),Prop2);
    	}
    }
    
    protected void RiseEvent(string propertyName, object propertyValue)
    {
    	//---Code that uses the propertyName and propertyValue and rises an event as your chosie
    }
