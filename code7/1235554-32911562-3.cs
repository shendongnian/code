    public Task DoSomethingAsync()
    {
        Task someTaskJustLikeANormalReturnValue = Task.Delay(1000);
        return someTaskJustLikeANormalReturnValue;
    }
    // later...
    public async Task SomeOtherFunction()
    {
        // You can await DoSomethingAsync just like any async method, because
        // you're really awaiting the Task which got returned.
        await DoSomethingAsync();
    }
