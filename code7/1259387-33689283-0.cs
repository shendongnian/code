	private CancellationTokenSource cts;
	private void btnGetAccount(object sender, RoutedEventArgs e) 
	{
		try
		{
			if (cts != null)
			{
				cts.Cancel();
			}
			cts = new CancellationTokenSource();
			var token = cts.Token;
			Task.Factory.StartNew(
				() =>
					{
						var found = SearchForAccount();
						
						if (!token.IsCancellationRequested)
						{
							Dispatcher.Invoke(
								() =>
									{
										SetStatusLabel(found ? "Found" : "Not found");
									});
						}
					},
					token);
		}
		catch (OperationCanceledException ex)
		{
			SetStatusLabel("Cancel done.");
		}
	}
