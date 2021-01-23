    public Task DoSomethingAsync()
    {
        return someTaskJustLikeANormalReturnValue;
    }
    // later...
    public async Task SomeOtherFunction()
    {
        await DoSomethingAsync(); // You can await DoSomethingAsync
    }
