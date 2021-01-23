    void Main()
    {
    	object x = "this is actually a string";
    	Console.WriteLine(GetRuntimeType(x));
    }
    
    public Type GetCompileTimeType<T>(T inputObject)
    {
    	return typeof(T);
    }
