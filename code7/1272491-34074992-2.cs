	public static void Main()
	{
		var boring = new BoringPlugin();
		Console.WriteLine(boring.Output());
		
		var exciting = new ExcitingPlugin();
		Console.WriteLine(exciting.Output());
	}
