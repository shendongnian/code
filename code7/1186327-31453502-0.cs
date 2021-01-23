	async void Button_whateverClickWithAsync(/*parameters*/)
	{
		var clients = await _access.GetAllClients();
		// Here, you execute the rest of your code as if
		// running synchronously.
	}
	void ButtonClick(/*parameters*/)
	{
		_access.GetAllClients().ContinueWith(HandleResult);
		// When does the continuation run? What happens if you want
		// to execute this only if the task fails?
	}
	
