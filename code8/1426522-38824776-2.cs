    public static void Main()
	{
		Random rnd = new Random();
		string Value = rnd.Next(1, 9999).ToString("D6");
		Console.WriteLine(Value);
	}
