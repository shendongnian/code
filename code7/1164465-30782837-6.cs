    private void ShowWindow()
    {
        var aTimeWindow = new TimeWindow();
        aTimeWindow.Show();
        
        Task.Run(()=>
        {
        	DoWork();
        })
    	.ContinueWith((t) =>
    	{		
    		Application.Current.Dispatcher.BeginInvoke((Action)(() => 
    		{
    			aTimeWindow.Close();    
    		}));
    	});
    }
    
    private void DoWork()
    {
        // perform long running work here
    }
