	void Main()
	{
		var foo = new Foo();
		foo.Blah += Qaz;
		foo.Blah += null;
		foo.OnBlah();
	}
	
	public void Qaz()
	{
		Console.WriteLine("Qaz");
	}
	
	public class Foo
	{
		public event Action Blah;
		public void OnBlah()
		{
			var b = Blah;
			if (b != null)
			{
				Console.WriteLine("Calling Blah");
				b();
				Console.WriteLine("Called Blah");
			}
		}
	}
