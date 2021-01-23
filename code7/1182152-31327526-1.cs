	enum testGroup
	{
		e0 = test1.byte1,
		e1 = test1.byte2,
		e2 = test1.byte3,
		e10 = test2.byte1,
		e20 = test2.byte2,
		e30 = test2.byte3,
	}
	testGroup tg = (testGroup)test1.byte3;
	Console.WriteLine(tg); // prints e2
	Console.WriteLine((int)tg); // prints 2
