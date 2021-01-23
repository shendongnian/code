	void Main()
	{
		var foo = new Foo() { Color = System.Drawing.Color.Red };
	
		if (foo.Color.R == 45 && foo.Color.B == 55)
		{
			Console.WriteLine("!");
		}
	}
	
	public class Foo
	{
		public System.Drawing.Color Color;
	}
