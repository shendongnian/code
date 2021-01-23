    static void Main(string[] args)
    {
        MainAsync().Wait();
    }
    static async Task MainAsync()
    {
        Task firstTask = new Task(()=>getPackage(packageId));
        firstTask.ContinueWith(()=>UpdatePackage(myPackage)));
        await firstTask.Run();
    }
