    public static void Main()
    {
        MainAsync().Wait();
    }
    
    public async Task MainAsync()
    {
        // calling thread
        await Task.Delay(1000);
        // different ThreadPool thread
    }
