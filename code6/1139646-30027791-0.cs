    public Task<string> GetXmlReportAsync()
    {
    	var tcs = new TaskCompletionSource<string>();
    	ReportUtilities reportUtil = new ReportUtilities(_user,queryString,"XML");
    	
    	reportUtil.GetResponseAsync(callBack => 
    	{
    		// I persume this would be the callback invoked once the download is done
    		// Note, I am assuming sort sort of "Result" property provided by the callback,
    		// Change this to the actual property
    		byte[] data = callBack.Result;
    		tcs.SetResult(Encoding.UTF8.GetString(data));
    	});
    	
    	return tcs.Task;
    }
