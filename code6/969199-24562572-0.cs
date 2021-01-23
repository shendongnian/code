	interface ITest
	{
		string Say();
	}
	
	class Test1 : ITest
	{
		private string message;
	
		public Test1(string message)
		{
			this.message = message;
		}
	
		public string Say()
		{
			return this.message;
		}
	}
	
	class Test2 : ITest
	{
		private string message;
	
		public Test2(string message)
		{
			this.message = message;
		}
	
		public string Say()
		{
			return this.message;
		}
	}
	
	void Main()
	{
		string[] args = new string[] { "Hello", "World" };
		var tests = Assembly.GetExecutingAssembly().GetTypes()
			.Where(t => t.GetInterfaces().Contains(typeof(ITest)))
			.Select((t, i) => Activator.CreateInstance(t, args[i]) as ITest);
	
		foreach (var item in tests)
		{
			Console.WriteLine(item.Say());
		}
	}
