	async void DoSomethingAsync()
	{
		cts = new CancellationTokenSource();
		try
		{
			await SuperSlowProcess(cts.Token);
			MessageBox.Show("You will only see this if execution is not cancelled");
		}
		catch (OperationCanceledException) // Note that exception type is different
		{
			MessageBox.Show("Execution was cancelled");
		}
	}
