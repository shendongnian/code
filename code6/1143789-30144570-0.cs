	public static void Main()
	{
		
		int myInt = 5;
		
		Console.WriteLine(myInt);
		ChangeMe(myInt);
		Console.WriteLine(myInt);
	}
	
	public static void ChangeMe(int i)
	{
		i = 7;
	}
    // Outputs:
    // 5
    // 5
