    static void Main(string[] args)
    {
        Task t = AsyncMain(args);
        t.Wait();
    }
    
    async static Task AsyncMain(string[] args)
    {
        await Task.Delay(1000); // Real async code here.
        Console.WriteLine("Awaited a delay of 1s");
        return;
    }
