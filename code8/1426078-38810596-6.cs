    string temp = "abc";
	var c = new SomeClass
	{
		Prop1 = temp,
		Prop2 = temp
	};
	Console.WriteLine(c.Prop1); // prints "abc"
	Console.WriteLine(c.Prop2); // prints "abc"
