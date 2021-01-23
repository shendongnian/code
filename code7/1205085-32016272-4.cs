    public async Task Test()
    {
        Task<string> task = Task.Factory.FromAsync(foo.BeginSampleFunction, foo.EndSampleFunction, null);
        string result = await task;
        Console.WriteLine(result);
    }
