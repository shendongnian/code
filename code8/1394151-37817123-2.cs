    // synchronous
    public override Task<bool> Run()
    {
        var result = DoSomething();
        return Task.FromResult(result);
    }
    // asynchronous
    public override async Task<bool> Run()
    {
        var result = await DoSomethingAsync();
        return result;
    }
