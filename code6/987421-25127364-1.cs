    public async Task<string> GetGridDataAsync()
    {
    	var proxy = new Proxy();
    	return await Task.Factory.FromAsync(proxy.BeginGetDataAsync, proxy.EndGetDataAsync, "test", null);   
    }
