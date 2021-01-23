    static EmptyArray()
    {
       Instance = new T[0];
	   Console.WriteLine("Array of "+ typeof(T) + " is created.");
    }
    var s = EmptyArray<string>.Instance;
	s = EmptyArray<string>.Instance;
	s = EmptyArray<string>.Instance;
    var i = EmptyArray<int>.Instance;
    i = EmptyArray<int>.Instance;
    // output:
    // Array of System.String is created.
    // Array of System.Int32 is created.
