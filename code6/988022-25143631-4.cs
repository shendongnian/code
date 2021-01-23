    [HttpGet]
    [Route("GetGridDataAsync")]
    public async Task<IEnumerable<DataResponse>> GetGridDataAsync()
    {
        var proxy = new Proxy();
        return await proxy.GetGridDataAsync(dataRequest, new object());
    }
