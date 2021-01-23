	private static void Main(string[] args)
	{
		IEnumerable<Type> arg_33_0 = typeof(Program).Assembly.GetTypes();
		Func<Type, bool> arg_33_1;
		if (arg_33_1 = Program.<>c.<>9__0_0 == null)
		{
			arg_33_1 = Program.<>c.<>9__0_0 = 
							new Func<Type, bool>(Program.<>c.<>9.<Main>b__0_0);
		}
		using (IEnumerator<Type> enumerator = arg_33_0.Where(arg_33_1).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Console.WriteLine(enumerator.Current.FullName);
			}
		}
		Console.ReadKey();
	}
	
	[CompilerGenerated]
	[Serializable]
	private sealed class <>c
	{
		public static readonly Program.<>c <>9;
		public static Func<Type, bool> <>9__0_0;
		static <>c()
		{
			// Note: this type is marked as 'beforefieldinit'.
			Program.<>c.<>9 = new Program.<>c();
		}
		internal bool <Main>b__0_0(Type t)
		{
			return !t.IsAbstract && t.IsClass;
		}
	}
