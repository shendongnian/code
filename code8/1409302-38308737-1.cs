	private async void asynchWork()
	{
		// Line 1
		Task<string> readTask = asynchAwaitWork();
		// Line 2
		synchWork();
		// Line 3
		string result = await readTask;
		// Line 4
		Debug.WriteLine(result);
		Debug.WriteLine("The End");
	}
	private void synchWork()
	{
		for (int i = 0; i < 5; i++)
		{
			Debug.WriteLine("SynchWork For i : " + i + " and thareadId = " + Thread.CurrentThread.ManagedThreadId);
			Thread.Sleep(750);
		}
	}
	private async Task<string> asynchAwaitWork()
	{
		for (int i = 0; i < 15; i++)
		{
			Debug.WriteLine("A-SynchWork For i : " + (i + 111) + " and thareadId = " + Thread.CurrentThread.ManagedThreadId);
			await Task.Delay(750);
			//Thread.Sleep(750);
		}
		return "finished";
	}
