    public async Task Process()
    {
        WebJob[] jobs = CreateWebJobs(); // dummy jobs
        await Task.WhenAll(jobs.Select(ExecuteJob));
    }
    private async Task ExecuteJob(WebJob job, [CallerMemberName] string memberName = "")
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Caller> {0} :: {1} Job> {2} :: {3} Thread> {4}", memberName, "\t", job.Name, "\t", Thread.CurrentThread.ManagedThreadId);
        await GetDataAsync(job);
        if (job.Children != null)
        {
            var childTasks = job.Children.Select(r =>
            {
                r.ParentResponse = job.Response;
                return ExecuteJob(r);
            });
            await Task.WhenAll(childTasks);
        }
    }
