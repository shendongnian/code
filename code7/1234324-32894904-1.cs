	public Task<string> DoHeavyLiftingAsync()
	{
		var tcs = new TaskCompletionSource<string>();
		string result = SomeHeavyWork();
		return tcs.SetResult(result);
	}
	
