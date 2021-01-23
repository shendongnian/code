	public async Task FooTestAsync()
	{
		var task = Task.Run(() => stubbedQueueHandler.QueueProcessor(setupModel));
		await Task.Delay(2000);
	    stubbedQueueHandler.QueueProcessor(setupModel);
	    await task;
	}
