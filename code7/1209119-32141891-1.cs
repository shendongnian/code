	static void Main(string[] args)
	{
		string s = "ac";
		foreach(int unicodeCodePoint in s.GetUnicodeCodePoints())
		{
			Console.WriteLine(unicodeCodePoint);
		}
	}
