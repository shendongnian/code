	void Main()
	{
	    var foos = new Foo[]
		{
			new Foo() { Color = System.Drawing.Color.Red },
		};
	
	    if (foos[0].Color.R == 45 && foos[0].Color.B == 55)
	    {
	        Console.WriteLine("!");
	    }
	}
	
	public struct Foo
	{
	    public System.Drawing.Color Color;
	}
