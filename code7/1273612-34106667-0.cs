	public static Task<string> Process(Stream data)
	{
        var handle = new AutoResetEvent(false);
		var client = new ServiceClient();
		var tcs = new TaskCompletionSource<string>();
		client.OnResult += (sender, e) =>
		{
			tcs.SetResult(e.Result);
            handle.Set();
		};
		client.OnError += (sender, e) =>
		{
			tcs.SetException(new Exception(e.ErrorMessage));
            handle.Set();
		};
		client.Send(data);
        handle.WaitOne(10000); // wait 10 secondds for results
		return tcs.Task;
	}
