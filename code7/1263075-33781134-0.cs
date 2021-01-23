	public static void Main(string[] args)
	{
		var test = new Test { Value = 1, NiceString = "First" };
		var newTest = new Test { Value = 2, NiceString = "AlteredTest!" };
		
		UpdateTest(ref test, newTest);
		Console.WriteLine(test.NiceString); // "AlteredTest!"
	}
	public static void UpdateTest(ref Test originalTest, Test other)
	{
		originalTest = other;
	}
