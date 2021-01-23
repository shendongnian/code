    private void OnIsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs args)
    {
    	if(args.IsBrowserInitialized)
    	{
    		browser.ExecuteScriptAsync("alert('test');");
    	}
    }
