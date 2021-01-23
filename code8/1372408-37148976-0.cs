    void Main()
    {
    	new Test().Dump("result");
    }
    
    // Define other methods and classes here
    class Test
    {
    	public int MyProperty1 { get; set; } = 1.Dump("auto-prop init");
    	public Test()
    	{
    		MyProperty1 = 2.Dump(".ctor");
    		MyProperty2 = 2.Dump(".ctor");
    	}
    	public int MyProperty2 { get; set; } = 1.Dump("auto-prop init");
    }
