	public Task ParseDocumentAsync() 
	{
		return Task.Run( () => {
			// your long processing parsing code here
		});
	}
	public async void DoIt() {
		WordFileLocation = "Someplace a dialogue selected";
		Text = "Begin";
		await ParseDocumentAsync(); // public Task ParseDocumentAsync() { } 
		Text = "ParseDocumentDone()";
		Text = "Wait 3 seconds";
		await Task.Delay(3000);
		Text = "Run non-Task methods";
		Task.Run( () => LongRunningNonAsyncMethod(); );
		Text = "LongRunningNonAsyncMethod() finished. Wait 2 seconds";
		// DON'T DO THIS. It will block the UI thread! 
		// It has no await, it runs on the thread which started everything, 
		// which is UI Thread in this case, because the View invoked the command.
		// That's why it locks the UI
		Thread.Sleep(2000); 
		Text = "Waited 2 seconds. We won't see this, because UI is locked";
		// DON'T DO THIS, it will ALSO block the UI Thread. 
		LongRunningNonAsyncMethod(); 
		Text = "Finished";  
	}
