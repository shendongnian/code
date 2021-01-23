    static void Main(string[] args)
    {
        MainAsync(args).Wait();
    }
    static async Task MainAsync(string[] args)
    {
        // creating Enumerable of jobs
        // ...
        IEnumerable<Task> tasks = jobs.Select(job => client.SubmitJob(job));
        await Task.WhenAll(tasks);
    }
