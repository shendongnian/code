    private DateTime previousTime;
    private CancellationTokenSource cts;
     
    private async void ButtonClickHandlerAsync(object sender, EventArgs e)
    {
    	button1.Enabled = false;
    	var count = 0;
    	previousTime = DateTime.Now;
    	cts = new CancellationTokenSource();
    	try
    	{
    		CancellationToken token = cts.Token;
    		await Task.Run(() =>
    		{
    			for (var i = 0; i <= 5000000; i++)
    			{
    				token.ThrowIfCancellationRequested();
    				UpdateUI(i);
    				count = i;
    			}
    		}, token);
    	}
    	catch (System.OperationCanceledException)
    	{
    		MessageBox.Show("Canceled");
    	}
    	finally
    	{
    		cts.Dispose();
    		cts = null;
    	}
    	label1.Text = @"Counter " + count;
    	button1.Enabled = true;
    }
