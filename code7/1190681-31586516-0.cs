	public static void Main(string[] args)
	{
		Program.<>c__DisplayClass0_0 <>c__DisplayClass0_ = new Program.<>c__DisplayClass0_0();
		<>c__DisplayClass0_.x = 1;
		Action action = new Action(<>c__DisplayClass0_.<Main>b__0);
		<>c__DisplayClass0_.x = 3;
		action();
		Console.WriteLine(<>c__DisplayClass0_.x);
	}
	
	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_0
	{
		public int x;
		internal void <Main>b__0()
		{
			Console.WriteLine(this.x);
			this.x = 2;
		}
	}
	
