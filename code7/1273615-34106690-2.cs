	public static class ServiceClientExtensions
	{
		public static Task<string> ProcessAsync(this ServiceClient client, Stream data)
		{
			var tcs = new TaskCompletionSource<string>();
			
			EventHandler resultHandler = null;
			resultHandler = (sender, e) => 
			{
				client.OnResult -= resultHandler;
				tcs.SetResult(e.Result);
			}
			
			EventHandler errorHandler = null;
			errorHandler = (sender, e) =>
			{
				client.OnError -= errorHandler;
				tcs.SetException(new Exception(e.ErrorMessage));
			};
		
			client.OnResult += resultHandler;
			client.OnError += errorHandler;
			
			client.Send(data);
			return tcs.Task;
		}
	}
	
