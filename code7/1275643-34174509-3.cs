	public static void Main()
	{
		int num = readNumber("Enter an integer to be doubled: ");
		int result = Double(num);
		Console.WriteLine("The double of {0} is {1}", num, result);
		Console.WriteLine("Press enter to exit...");
		Console.ReadLine();
	}
	
