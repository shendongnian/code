	class Program
	{
		static void Main(string[] args)
		{
			TerminalHost terminal = new TerminalHost();
			terminal.Use(next => ch => {
				Console.WriteLine(ch);
				next(ch);
			});
			terminal.Start();
		}
	}
