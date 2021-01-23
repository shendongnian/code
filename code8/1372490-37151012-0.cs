    	public static void Main()
	{
		Console.WriteLine("main");
		var t = func1();
		func2();
		t.Wait();
	}
	
	public static Task func1()
	{
		Console.WriteLine("func1");
		return Task.Factory.StartNew(() => {
			double i = 0;
			while(true)
			{
			  i += 1;
			  if (i > 100000000)
			  {
			   break;
			  }
			}
			func(3);
			func(4);
		});
	}
	public static void func2()
	{
		Console.WriteLine("func2");
		func(5);
		func(6);
	}
	public static void func(int number)
	{
		Console.WriteLine(number);
	}
