    public void Process()
    {
        WebJob[] jobs = CreateWebJobs(); // dummy jobs
        Task.WaitAll(jobs.Select(ExecuteJob));
    }
