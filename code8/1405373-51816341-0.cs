    [HttpGet]
    public async Task<string> Get()
    {
        Request.HttpContext.RequestAborted.WaitHandle.WaitOne(60000);
        return null;
    }
