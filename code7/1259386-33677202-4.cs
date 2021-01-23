    //property of the class
    private readonly CancellationTokenSource cts = new CancellationTokenSource();
    
    private void btnDo(object sender, RoutedEventArgs e) {
    	var found = Task.Factory.StartNew(() =>
    	{
    		try
    		{
    			while (true)
    			{
    				cts.Token.ThrowIfCancellationRequested();
    				//loop's body
    			}
    		}
    		catch (OperationCanceledException ex)
    		{
    			SetStatusLabel("Cancel done.");
    		}
    	}, cts.Token);
    }
    
    private void btnCancel(object sender, RoutedEventArgs e) {
    	//cancelling
    	cts.Cancel();
    }
