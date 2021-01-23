    public void Testing()
    {
    	bool? boolValue = new bool?(true);
    	bool valueOrDefault = boolValue.GetValueOrDefault();
    	if (boolValue.HasValue)
    	{
    		Console.WriteLine("default");
    	}
    	else
    	{
    		Console.WriteLine("null");
    	}
    }
