    public async Task FooAsync()
    {
        await Task.Factory.StartNew(_ => Console.WriteLine("Foo"),
                                         CancellationToken.None,
                                         TaskCreationOptions.LongRunning);
    }
    
