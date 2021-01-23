    [HttpGet]
    [Route("GetGridDataAsync")]
    public async Task<IEnumerable<DataResponse>> GetGridDataAsync()
    {
        var proxy = new Proxy();
        var  result = await proxy.GetGridDataAsync(dataRequest, new object());
        return result
    }
