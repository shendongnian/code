    //Better use thread-safe ConcurrentQueue
	private ConcurrentQueue<Task<ResponseBase>> _actions;
	public ExecutingScheduler()
	{
		_actions = new ConcurrentQueue<Task<ResponseBase>>();
		Task.Factory.StartNew(ExecuteNextTask);
	}
	private void ExecuteNextTask()
	{
		while (true)
		{
			// Get first while removing it
			Task<ResponseBase> next;
			var containsElement = _actions.TryDequeue(out next);
			if (containsElement)
			{
				next.Start();
				next.Wait();
			}
			Task.Delay(2000);
		}
	}
	public async Task<ResponseBase> StartStreamAsync(ClassA classA, ClassB classB)
	{
		var task = new Task<ResponseBase>(() => StartStream(classA, classB));
		//Add task to queue
		_actions.Enqueue(task);
		var result = await task;
		return result;
	}
	public async Task<ResponseBase> PrepareStreamAsync(ClassA classA, ClassB classB)
	{
		var task = new Task<ResponseBase>(() => PrepareStream(classA, classB));
		//Add task to queue
		_actions.Enqueue(task);
		var result = await task;
		return result;
	}
