	static void Main(string[] args)
	{
		var x = new X
		{
			RegistrationIds = new List<string> { "1", "2" },
			Data = new List<string> { "hello" }
		};
		Console.WriteLine(JsonConvert.SerializeObject(x));
	}
	
