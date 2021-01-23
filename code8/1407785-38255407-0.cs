	public static void Main(string[] args)
	{
		Process.Start("tput", "civis -- invisible");
		Console.WriteLine("Hello World!");
		Console.Read(); // no cursor
		Process.Start("tput", "cnorm -- normal");
		Console.Read(); // with cursor
	}
