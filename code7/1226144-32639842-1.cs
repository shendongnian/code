    public async Task GetFooAsync()
    {
        await DoSomethingElseAsync();
    }
    public static void MySyncMethod()
    {
        GetFooAsync().Wait();
    }
