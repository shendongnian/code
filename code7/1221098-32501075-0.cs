	RunMethodWithMeasurementsOn(MethodWithNoParams);
	RunMethodWithMeasurementsOn(() => { MethodWithOneParam(5); });
    public void MethodWithNoParams()
    {
    	Console.WriteLine("MethodWithNoParams");
    }
    
    public void MethodWithOneParam(int a)
    {
    	Console.WriteLine("MethodWithOneParam: " + a);
    }
