    static void Main(string[] args)
    {
        Func<Task> doAsync = async () =>
        {
            await FooAsync();
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
