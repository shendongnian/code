    private void frmSplash_Load(object sender, EventArgs e)
    {
    	MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
    
    	System.Threading.Tasks.Task.Factory.StartNew(() =>
    	{
    		MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
    		while(true)  //Fake loop
    		{
    			//Do some time consuming work
    			//Raise progress
    			this.InvokeEx(() => { /*Your method to update UI */ });
    			//Now sleep :)
    			System.Threading.Tasks.Task.Delay(5000);
    			//Do some more time consuming work
    		}
    
    	}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
    }
