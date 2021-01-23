	public async Task FooAsync()
	{
		var waitCounter = -1;
		var task = Task.Run(() => { });
		do
		{
			waitCounter++;
			await Task.Delay(1000);
		}
		while (!task.IsCompleted)
	}
