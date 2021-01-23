    static Task DoAsync<T>(Action<T> action, T arg)
	{
		return Task.Run(() => action(arg));
	}
	static void Main(string[] args)
	{
		Action<HelloWorld> hello = (HelloWorld h2) => { Console.WriteLine(h2.Name); };
		var h = new HelloWorld() { Name = "A" };
		Task task = DoAsync(hello, h);
		var h = new HelloWorld() { Name = "B" };
	}
