	void Main()
	{
		var tcs = new TaskCompletionSource<bool>();
		tcs.SetResult(true);
		Console.WriteLine(tcs.Task.IsCompleted); // prints true.
	}
	
