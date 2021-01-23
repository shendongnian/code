	public static int IPlusPlus(ref int i) {
		// simply increment i before returning it
		i = i + 1;
	    return i;
	}
    
	public static int PlusPlusI(ref int i) {
		// increment i only after you already returned it
		try {
			return i;
		}
		finally {
			i = i + 1;
		}
	}
    
	public static void Main()
	{
		int i = 5;
		Console.WriteLine(i); // prints 5
		Console.WriteLine(PlusPlusI(ref i)); // prints 5, but increments i afterwards
		Console.WriteLine(i); // prints 6
		Console.WriteLine(IPlusPlus(ref i)); // increments i, then prints 7
		Console.WriteLine(i); // prints 7
	}
