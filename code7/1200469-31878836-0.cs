    public async Task CallManyMethods(string someData)
    { 
        var tasks=new []{
            CallSvc1Async(someData),
            CallSvc2Async(someData),
        }
        var results=await Task.WhenAll(tasks);
        ...
        //Unpack the results and keep processing them
    }
    public async Task<string> CallSvc1Async(string someData)
    {
        var response=await _svc1Proxy.GetStuffAsync(someData);
        //build a result from the response
        return result;
    }
    public async Task<string> CallSvc2Async(string someData)
    {
        var url=....
        var json=await _httpClient.GetStringAsync(url);
        ....
        return result;
    }
