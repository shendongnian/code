    static void Main(string[] args)
    {
        int max = 10;
        List<Task> tasks = new List<Task>();
        for (int i = 0; i <= max; ++i)
        {
            tasks.Add(DoHeavyWork(i, max));
        }
        Task.WaitAll(tasks.ToArray());
    }
