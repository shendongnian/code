	public static void Main()
	{
		
		int myInt = 5;
		
		Console.WriteLine(myInt);
		ChangeMe(ref myInt);
		Console.WriteLine(myInt);
	}
	
	public static void ChangeMe(ref int i)
	{
		i = 7;
	}
    // Outputs:
    // 5
    // 7
