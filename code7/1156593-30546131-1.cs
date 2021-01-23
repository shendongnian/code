    private delegate void Del(string str);
	[CompilerGenerated]
	private static Launcher.Del CS$<>9__CachedAnonymousMethodDelegate3;
	[CompilerGenerated]
	private static Launcher.Del CS$<>9__CachedAnonymousMethodDelegate4;
	[CompilerGenerated]
	private static Launcher.Del CS$<>9__CachedAnonymousMethodDelegate5;
	private static void Main()
	{
		List<Launcher.Del> listDel = new List<Launcher.Del>();
		List<Launcher.Del> arg_24_0 = listDel;
		if (Launcher.CS$<>9__CachedAnonymousMethodDelegate3 == null)
		{
			Launcher.CS$<>9__CachedAnonymousMethodDelegate3 = 
                                     new Launcher.Del(Launcher.<Main>b__0);
		}
		arg_24_0.Add(Launcher.CS$<>9__CachedAnonymousMethodDelegate3);
		Console.WriteLine(listDel[0].Method.ToString());
		List<Launcher.Del> arg_5D_0 = listDel;
		if (Launcher.CS$<>9__CachedAnonymousMethodDelegate4 == null)
		{
			Launcher.CS$<>9__CachedAnonymousMethodDelegate4 = 
                                     new Launcher.Del(Launcher.<Main>b__1);
		}
		arg_5D_0.Add(Launcher.CS$<>9__CachedAnonymousMethodDelegate4);
		Console.WriteLine(listDel[1].Method.ToString());
		for (int i = 0; i < 2; i++)
		{
			List<Launcher.Del> arg_9A_0 = listDel;
			if (Launcher.CS$<>9__CachedAnonymousMethodDelegate5 == null)
			{
				Launcher.CS$<>9__CachedAnonymousMethodDelegate5 = 
                                     new Launcher.Del(Launcher.<Main>b__2);
			}
			arg_9A_0.Add(Launcher.CS$<>9__CachedAnonymousMethodDelegate5);
			Console.WriteLine(listDel[2 + i].Method.ToString());
		}
	}
	[CompilerGenerated]
	private static void <Main>b__0(string str)
	{
	}
	[CompilerGenerated]
	private static void <Main>b__1(string str)
	{
	}
	[CompilerGenerated]
	private static void <Main>b__2(string str)
	{
	}
