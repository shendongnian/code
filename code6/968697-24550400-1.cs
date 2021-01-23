    static async Task FooAsync()
    {
        Thread.Sleep(1000); // blocking 
        await Task.Delay(1000); // non-blocking
    }
    static void Main(string[] args)
    {
        Func<Task> doAsync = async () =>
        {
            await FooAsync().ConfigureAwait(false);
            List<Task> childTasks = new List<Task>();
            for (int i = 1; i <= 5; i++)
            {
                var childTask = FooAsync();
                childTasks.Add(childTask);
            }
            await Task.WhenAll(childTasks);
        };
        try
        {
            doAsync().Wait();
        }
        catch (AggregateException ag)
        {
            foreach (Exception ex in ag.Flatten().InnerExceptions)
            {
                Console.WriteLine(ex);
                //handle it
            }
        }
    }
