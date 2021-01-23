    public async Task<string> GetGridDataAsync()
    {
    	var proxy = new Proxy();
    	return await Task.Factory.FromAsync(proxy.BeginGetDataAsync("test", ar => proxy.EndGetDataAsync(ar)), EndGetDataAsync);
    }
