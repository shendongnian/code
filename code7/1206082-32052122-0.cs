    class myclass
    {
    	object internalConverter;
    	MethodInfo converterStringToValueMethod;
    	
    	public myclass()
    	{
    		// Here you need a reference to the assembly which contains the Converter type
    		Assembly asm = Assembly.Load("xxx.dll"); // Name of the assembly which contains Converter
    		Type converterType = asm.GetType("Converter");
    		this.internalConverter = Activator.CreateInstance(converterType);
    		
    		this.converterStringToValueMethod = converterType.GetMethod("StringToValue", BindingFlags.NonPublic | BindingFlags.Instance);
    	}
    	
    	public object StringToValue()
    	{
    		return converterStringToValueMethod.Invoke(internalConverter, null);
    	}
    }
