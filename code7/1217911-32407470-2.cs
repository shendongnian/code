    public void Testing()
    {
    	bool? flag = new bool?(true);
    	bool? flag2 = flag;
    	bool? flag3 = flag2;
    	if (flag3.HasValue)
    	{
    		bool valueOrDefault = flag3.GetValueOrDefault();
    	}
    	Console.WriteLine("null");
    }
    
