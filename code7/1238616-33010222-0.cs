	private static void Main(string[] args)
	{
		var taskList = new List<Task>();
		taskList.Add(Task.Factory.StartNew(() => new Program().Foo()).Unwrap());
		Task.WaitAll(taskList.ToArray());
	}
	
