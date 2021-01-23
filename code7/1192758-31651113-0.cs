	[CompilerGenerated]
	private static Comparison<int> CS$<>9__CachedAnonymousMethodDelegate2;
	public static void Main(string[] args)
	{
		List<int> ints = new List<int> { 3,2,1,8,5 };
		List<int> arg_51_0 = ints;
		
		if (Program.CS$<>9__CachedAnonymousMethodDelegate2 == null)
		{
			Program.CS$<>9__CachedAnonymousMethodDelegate2 = 
					new Comparison<int>(Program.<Main>b__1);
		}
		arg_51_0.Sort(Program.CS$<>9__CachedAnonymousMethodDelegate2);
	}
	[CompilerGenerated]
	private static int <Main>b__1(int x, int y)
	{
		return x.CompareTo(y);
	}
	
