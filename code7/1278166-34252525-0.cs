	public static void Main()
	{
		Task t = Task.Run(() =>
		{
			for (int x = 0; x < 100; x++)
			{
				Console.Write('*');
			}
		});
		t.Wait();
	}
