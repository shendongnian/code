    public static void varargs_m1(params object[] args) 
	{
        // Your new values
        var newValues = new object[]{ 0 };
        // Build a new array 
        var combined = new object[newValues.Length + args.Length];
        // Copy each of your values into the new array
        newValues.CopyTo(combined, 0);
        args.CopyTo(combined, newValues.Length);
        // Pass your new values along
		varargs_m2(combined);
	}
    
