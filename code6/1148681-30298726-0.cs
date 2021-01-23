	[CompilerGenerated]
	private static Func<string, bool> CS$<>9__CachedAnonymousMethodDelegate1;
	private static void Main(string[] args)
	{
		string[] strings = new string[]
		{
			"hello",
			"world"
		};
		IEnumerable<string> arg_3A_0 = strings;
		if (Program.CS$<>9__CachedAnonymousMethodDelegate1 == null)
		{
			Program.CS$<>9__CachedAnonymousMethodDelegate1 = new Func<string, bool>
                                                                 (Program.<Main>b__0);
		}
		arg_3A_0.Where(Program.CS$<>9__CachedAnonymousMethodDelegate1);
	}
	[CompilerGenerated]
	private static bool <Main>b__0(string x)
	{
		return x.Contains("h");
	}
