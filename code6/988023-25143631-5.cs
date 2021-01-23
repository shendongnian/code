    [HttpGet]
    [Route("GetGridDataAsync")]
    public Task<IEnumerable<DataResponse>> GetGridDataAsync()
    {
        return proxy.GetGridDataAsync(dataRequest, new object());
    }
