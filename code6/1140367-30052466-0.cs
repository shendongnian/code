    private Dictionary<Guid, TaskCompletionSource<bool>> transactions = new Dictionary<Guid, TaskCompletionSource<bool>>();
    
    public Task SendPrivateMessage(string content)
    {
		var taskCompletion = new TaskCompletionSource<bool>();
	    var transactionId = Guid.NewGuid();
		transactions[transactionId] = taskCompletion;
	    var message = new Message
	    {
			TransactionId = transactionId,
			Content = content
	    };
		GlobalHost
			.ConnectionManager
			.GetHubContext<MyHub>()
			.Clients
			.Client(connectionId)
			.OnMessage(message); 
		return taskCompletion.Task;
    }
    
    public void OnTransactionConfirmed(Guid transactionId)
    {
        var taskCompletion = transactions[transactionId];
        transactions.Remove(transactionId);
    	taskCompletion.SetResult(true);
    }
