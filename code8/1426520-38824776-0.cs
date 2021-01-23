    public static void Main()
	{
		Random rnd = new Random();
		string Value = rnd.Next(1, 9999).ToString("D4");
		Console.WriteLine("00" + Value);
	}
