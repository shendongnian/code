	Task.Run<BindingList<Client>>(() =>
	{
        // return all the clients to 'ContinueWith' task
		return new BindingList<Client>(Client.GetClients());
	})
	.ContinueWith(t =>
	{
        // Result is a dynamic property and holds the output of its previous Task. BindingList<Client> in this case.
		clients = t.Result;
        // Update UI
		cbxRtojClient.DataSource = clients; 
	}, TaskScheduler.FromCurrentSynchronizationContext()); // ensures calling the ContinueWith task to be run in the UI thread. 
