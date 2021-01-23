    void Main()
    {
    	object x = "this is actually a string";
    	Console.WriteLine(GetRuntimeType(x));
    }
    
    public Type GetRuntimeType<T>(T inputObject)
    {
    	return typeof(T);
    }
