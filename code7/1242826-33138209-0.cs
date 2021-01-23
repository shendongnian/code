    void Main()
    {
    	Type type;
    
    	type = this.GetType().GetMethod("Method").GetParameters()[0].ParameterType;
    	
    	Console.WriteLine("type is {0}", type.FullName);
    	Type underlyingType = Nullable.GetUnderlyingType(type);
    	if (underlyingType != null)
    	{
    		Console.WriteLine("underlying type is {0}", underlyingType);
    	}
    	else
    	{
    		Console.WriteLine("underlying type is null");
    	}
    }
    
    public void Method(out int? value)
    {
    	value = 42;
    }
