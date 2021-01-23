    public async Task FooAsync()
    {
        BarAsync().Wait(); // Don't do this!
    }
    public async Task BarAsync()
    {
        await Task.Delay(1000);
    }
