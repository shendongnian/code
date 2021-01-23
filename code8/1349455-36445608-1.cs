	static async Task MainAsync(string[] args)
	{
		int[] test = new[] { 1, 2, 3, 4, 5 };
		if (await test.AnyAsync(async i => await TestIt(i))
			Console.WriteLine("Contains numbers > 3");
		else
			Console.WriteLine("Contains numbers <= 3");
	}
	
