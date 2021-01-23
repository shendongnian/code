	public interface IFooBar 
	{
		...
	}
    // Option 1: Just type the parameter to the interface (the simplest)
	public static void MyFunction(IFooBar obj)
    {
    	// get data from order
    }
    // Option 2: Use a generic type parameter and constraint that it must 
    // be of type IFooBar (this can be useful for certain reflection scenarios)
    public static void MyFuntion<TObject>(TObject obj)
    	where TObject: IFooBar
    {
    	// get data from order
    }
    // Option 2a: Same as Option 2 however we take advantage of the constraint 
    // to inform the the compiler that TObject will have a default parameterless
    // constructor so we can actually instantiate TObject
    public static void MyFuntion<TObject>(TObject obj)
    	where TObject: IFooBar, new()
    {
    	// get data from order
        ...
        // We can do this because of the new() constraint
        return new TObject();
    }
