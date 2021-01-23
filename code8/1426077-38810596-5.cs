	var c = new SomeClass
	{
		Prop1 = "abc",
		Prop2 = Prop1 // won't compile. Can't reference Prop1 here.
	};
	Console.WriteLine(c.Prop1);
	Console.WriteLine(c.Prop2);
