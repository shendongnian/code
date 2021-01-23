    class MyComplexValue
    {
    	public int A { get; set; }
    	public int B { get; set; }
    	public int C { get; set; }
    	
    	public override string ToString()
    	{
    		return string.Format("A: {0}, B: {1}, C: {2}", A, B, C);
    	}
    }
    
    void Main()
    {
    	var hasSome = RustyEnum.Create(Option.Some, new MyComplexValue { A = 1, B = 2, C = 3});
    	var hasNone = RustyEnum.Create(Option.None, null as MyComplexValue);
    	
    	UseTheEnum(hasSome);
    	UseTheEnum(hasNone);
    }
    
    void UseTheEnum(RustyEnum<Option, MyComplexValue> item)
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
