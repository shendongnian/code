	public static class ServiceClientExtensions
	{
		public static Task<string> ProcessAsync(this ServiceClient client, Stream data)
		{
			var tcs = new TaskCompletionSource<string>();
			client.OnResult += (sender, e) =>
			{
				tcs.SetResult(e.Result);
			};
		
			client.OnError += (sender, e) =>
			{
				tcs.SetException(new Exception(e.ErrorMessage));
			};
		
			client.Send(data);
			return tcs.Task;
		}
	}
	
