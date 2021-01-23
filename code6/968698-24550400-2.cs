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
    static async Task FooAsync()
    {
        // simulate some CPU-bound work
        Thread.Sleep(1000); 
        // we could have avoided blocking like this:        
        // await Task.Run(() => Thread.Sleep(1000)).ConfigureAwait(false);
        // introduce asynchrony (FooAsync returns to the caller here)
        await Task.Delay(1000).ConfigureAwait(false);
    }
