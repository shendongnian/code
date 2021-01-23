    public Task<string> DownloadFileAsync(string url)
    {
        var tcs = new TaskCompletionSource<string>(); 
        DownloadFile myfile = new DownloadFile(url);
    	
    	myfile.Complete += (theData) =>
    	{
    	    tcs.SetResult(theData);
    	};
    	
    	return tcs.Task;
    }
