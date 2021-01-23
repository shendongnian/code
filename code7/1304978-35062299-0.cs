	CancellationTokenSource cts;
	private async button1_Click(object sender, EventArgs e)
    {
		toggleAsyncTask(false)
    }
	
	private void toggleAsyncTask(bool isCancelled){
	
		if(cts==null)
			var cts = new CancellationTokenSource();
		if(!isCancelled)
		{
			await measurements(cts.Token);
		}
		else
		{
			cts.Cancel();
	        cts.Dispose();
			cts = null;
		}
	}
    private async Task measurementsOne(CancellationToken token)
    {
		try
		{
			while(true){
				//Make some measurements
				await Task.Delay(120000); // don't know if you need this.
				//Make measurements, present data in the UI form.
				//return if done
        }
		catch(OperationCancelledException)
		{
			// to do if you please.
		}
    }
	
	private void button7_Click(object sender, EventArgs e)
    {
		// button stuff
        toggleAsyncTask(true); // isCancelled is true.          
    }
