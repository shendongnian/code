    using System;
    class Program
    {
    static void Main()
    {
	int[] integerArray = new int[]
	{
	    10000,
	    600,
	    1,
	    5,
	    7,
	    3,
	    1492
	};
	// This will track the lowest number found
	int lowestFound = int.MaxValue;
	foreach (int i in integerArray)
	{
	    // By using int.MaxValue as the initial value,
	    // this check will usually succeed.
	    if (lowestFound > i)
	    {
		lowestFound = i;
		Console.WriteLine(lowestFound);
	    }
	}
    }
    }
