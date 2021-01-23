    public override async void CanClose(Action<bool> callback)
    {
       await CanCloseAsync(callback);
    }
    public async Task CanCloseAsync(Action<bool> callback)
    {
        var result1 = await DoTask1();
        if (result1)
            await DoTask2();
        callback(result1);
    }
