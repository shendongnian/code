    static void Main(string[] args)
    {
        Task firstTask = Task.Run(DoFirstThing);
        firstTask.Wait();
        ...
    }
    public async static Task DoFirstThing()
    {
        Console.WriteLine("Doing first...");
        Task t = Task.Run(FirstThing);
        await t;
    }
    private async static Task FirstThing() { ... }
