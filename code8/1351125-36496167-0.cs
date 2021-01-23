    private static void RunTasks()
    {
        List<Task> tasks = new List<Task>();
        for (int i = 0; i < maxLoops; i++)
        {
            tasks.Add(Task.Factory.StartNew(PerformComputations, TaskCreationOptions.LongRunning));
        }
        Task.WaitAll(tasks.ToArray());
    }
