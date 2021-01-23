    public static async Task RunAsync() 
    {
        var tasks = new List<Task>();
        for(int i = 0; i < 5; i++) {
            tasks.Add(getSessionAsync());
        }
        await Task.WhenAny(tasks);
        await doMoreStuff();
    }
