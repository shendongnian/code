	// Simulate Application_Start
	public static void Main()
	{
		var appendToFileTimer = new Timer(AppendToFile, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
	}
	public static void AppendToFile(Object state)
	{
		Console.WriteLine("Append to file");
	}
