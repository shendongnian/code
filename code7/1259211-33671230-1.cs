	void Main()
	{
		var f = new Foo();
		Console.WriteLine(Marshal.SizeOf(f));
	}
	
	public struct Foo
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
	
