	public foo()
	{
		this.token = "Initial Value";
	}
	private void DoIt(string someString)
	{
		Console.WriteLine("SomeString is '{0}'", someString);
	}
	public void Run()
	{
		Action action = new Action(this.<Run>b__3_0);
		this.token = "Changed value";
		action();
	}
	[CompilerGenerated]
	private void <Run>b__3_0()
	{
		this.DoIt(this.token);
	}
	
