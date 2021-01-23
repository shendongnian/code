    [HttpGet]
    public async Task<string> TestThreadAbortException()
    {
        InitToolkit(); // Initialize Logger, DB etc.
        var result = await DoAfter(5.Seconds(), MyAction);
        return result;
    }
    
