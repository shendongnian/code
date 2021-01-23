	[CompilerGenerated]
	private static Func<Type, bool> CS$<>9__CachedAnonymousMethodDelegate1;
	private static void Main(string[] args)
	{
		IEnumerable<Type> arg_34_0 = typeof(Program).Assembly.GetTypes();
		if (Program.CS$<>9__CachedAnonymousMethodDelegate1 == null)
		{
			Program.CS$<>9__CachedAnonymousMethodDelegate1 = 
								new Func<Type, bool>(Program.<Main>b__0);
		}
		IEnumerable<Type> types =
					arg_34_0.Where(Program.CS$<>9__CachedAnonymousMethodDelegate1);
					
		foreach (Type type in types)
		{
			Console.WriteLine(type.FullName);
		}
		Console.ReadKey();
	}
	[CompilerGenerated]
	private static bool <Main>b__0(Type t)
	{
		return !t.IsAbstract && t.IsClass;
	}
