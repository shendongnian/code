	public Task Process(CancellationTokenSource token)
	{
		SOMETYPE[] tasks = new SOMETYPE[] {LongTask1, LongTask2, LongTask3, LongTask4, LongTask5};
		await SpinUpServiceAsync();
		foreach (var item in LongList())
		{
            bool exit=false;
			foreach(var task in tasks){
                if (token.IsCancellationRequested) {
				    Log($"Cancelled during {item}");
                    await SpinDownServiceAsync();
                    exit = true;
                    return;
                }
			    await task(item);
			}
            if (exit) {
               return;
            }
		}
	}
