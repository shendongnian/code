	const string FooName = nameof(Foo);
	const string BarName = nameof(Bar);
	
	private static void Test(object x)
	{
		switch(x.GetType().ToString())
		{
			case FooName:
				Console.WriteLine("Inside Foo's code");
			break;
			
			case BarName:
				Console.WriteLine("Inside Bar's code");
			break;
		}
	}
