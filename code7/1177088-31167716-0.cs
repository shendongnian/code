    enum Option
    {
    	Some,
    	None
    }
    
    class RustyEnum<TType, TValue>
    {
    	public TType EnumType { get; set; }
    	public TValue EnumValue { get; set; }
    }
    
    // This static class basically gives you type-inference when creating items. Sugar!
    static class RustyEnum
    {
    	// Will leave the value as a null `object`. Not sure if this is actually useful.
    	public static RustyEnum<TType, object> Create<TType>(TType e)
    	{
    		return new RustyEnum<TType, object>
    		{
    			EnumType = e,
    			EnumValue = null
    		};
    	}
    	
    	// Will let you set the value also
    	public static RustyEnum<TType, TValue> Create<TType, TValue>(TType e, TValue v)
    	{
    		return new RustyEnum<TType, TValue>
    		{
    			EnumType = e,
    			EnumValue = v
    		};
    	}
    }
    
    void Main()
    {
    	var hasSome = RustyEnum.Create(Option.Some, 42);
    	var hasNone = RustyEnum.Create(Option.None, 0);
    	
    	UseTheEnum(hasSome);
    	UseTheEnum(hasNone);
    }
    
    void UseTheEnum(RustyEnum<Option, int> item)
    {
    	switch (item.EnumType)
    	{
    		case Option.Some:
    			Debug.WriteLine("Wow, the value is {0}!", item.EnumValue);
    			break;
    		default:
    			Debug.WriteLine("You know nuffin', Jon Snow!");
    			break;
    	}
    }
