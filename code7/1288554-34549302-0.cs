    var config = new HttpSelfHostConfiguration("http://localhost:9999");
    var tcs = new TaskCompletionSource<Uri>();
    
    using (var server = new HttpSelfHostServer(config, new MessageHandler(tcs)))
    {
    	await server.OpenAsync();
    	
    	await tcs.Task;
    	
    	await server.CloseAsync();
    }
    
    return tcs.Task.Result;
    
    class MessageHandler : HttpMessageHandler
    {
    	private readonly TaskCompletionSource<Uri> _task;
    	
    	public MessageHandler(TaskCompletionSource<Uri> task)
    	{
    		_task = task;
    	}
    
    	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    	{
    		_task.SetResult(request.RequestUri);
    		return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
    	}
    }
