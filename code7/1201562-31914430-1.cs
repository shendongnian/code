	public static void Main(string[] args)
	{
		ISomeInterface[] somes = new[] { new SomeConcreteType() }
		Foo(somes);
		Console.WriteLine(somes.Length) // Will print 1
		Foo(ref somes);
		Console.WriteLine(somes.Length) // Will print 0
	}
	public List<Label> Foo(ref ISomeInterface[] all)
	{
		all = new ISomeInterface[0];
	}
	public List<Label> Foo(ISomeInterface[] all)
	{
		all = new ISomeInterface[0];
	}
