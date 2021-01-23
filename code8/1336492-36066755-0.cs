    public async PerformProcessingAsync()
    {
    	var ioProcessingResult = await StartSomeIOProcessing();
        return (null != ioProcessingResult);
    }
    
    private Task<TheIOProcessingResultType> StartSomeIOProcessing()
    {
    	return Task.Run(()=>
    	{
    		return StartSomeIOProcessing();
    	});
    }
