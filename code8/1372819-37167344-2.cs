	static string HelloWorld1()
	{
		return "Hello world!";
	}
	static async Task RunTest<T>(int num, Func<Task<T>> func)
	{
		try
		{
			Console.WriteLine($"Test {num}: {await func()}");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Test {num} failed: {ex.Message}");
		}
	}
	[Serializable]
	public struct Fun
	{
		public string Text;
		public int Number;
		public override string ToString() => $"{Text} ({Number})";
	}
	static async Task MainAsync(string[] args)
	{
		await RunTest(1, () => Runner.Run(HelloWorld1));
		await RunTest(2, () => Runner.Run(() => "Hello world from a lambda!"));
		await RunTest(3, () => Runner.Run(() => 42));
		await RunTest(4, () => Runner.Run(() => new Fun{Text = "I also work!", Number = 42}));
	}
