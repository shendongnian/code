    private static void Main(string[] args)
    {
        var task = DoBackgroundWork();
        System.Console.WriteLine("Doing something else during background work");
        // Wait for all created Tasks to complete before terminating
        task.Wait();
    }
    private static Task DoBackgroundWork()
    {
        var task = Task.Run(() =>
        {
            System.Console.WriteLine("Starting background work");
            Thread.Sleep(1000);
            System.Console.WriteLine("Background work finished!");
        });
        return task;
    }
