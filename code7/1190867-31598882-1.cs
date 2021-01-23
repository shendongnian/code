	static void Main(string[] args)
	{
		while(true)
		{
			Console.Clear();
			Console.WriteLine("Top");
			for (int x = 0; x < Console.WindowWidth; x++)
			{
				for (int y = 1; y < Console.WindowHeight - 1; y++)
				{
					Console.SetCursorPosition(x, y);
					Console.Write("X");
				}
			}
			Console.SetCursorPosition(0, Console.WindowHeight - 1);
			Console.Write("Prompt: ");
			Console.ReadLine();
		}
	}
