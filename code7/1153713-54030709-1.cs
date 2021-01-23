        static async Task Main(string[] args)
		{
			await MyMethod();
			await MyOtherMethod();
			Console.WriteLine("Done!");
		}
		private static async Task MyMethod()
		{
			// do something
			await Task.CompletedTask;
		}
		private static async Task MyOtherMethod()
		{
			// do something
			await Task.CompletedTask;
		}
