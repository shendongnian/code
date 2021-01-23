	public async Task<string> SendMessageAsync(string message)
	{
		var tcs = new TaskCompletionSource<string>();
		
		ReceiveMessangeEventHandler eventHandler = null;
		eventHandler = (sender, returnedMessage) =>
		{
			tcs.SetResult(returnedMessage);
		}
		
		RecieveMessage += eventHandler;
		
		Send(message);
		return tcs.Task;
	}
	
