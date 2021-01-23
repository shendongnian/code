    TaskFactory taskFactory = new TaskFactory(new WorkStealingTaskScheduler(Environment.ProcessorCount));
    public Job[] GetJobs() { get { return new Job[15000];} }
    public async Task ProcessJobs(Job[] jobs)
    {
        var jobTasks = jobs.Select(j => StartJob(j));
        await Task.WhenAll(jobTasks);
    }
    private async Task StartJob(Job j)
    {
        var initialCpuResults = await taskFactory.StartNew(() => j.DoInitialCpuWork());
        var wcfResult = await DoIOCalls(initialCpuResults);
        await taskFactory.StartNew(() => j.DoLastCpuWork(wcfResult));
    }
    private async Task<bool> DoIOCalls(Result r)
    {
        // Sequential...
        await myWcfClientProxy.DoIOAsync(...); // These MUST be fully IO completion port based methods [not Task.Run etc] to achieve good throughput
        await mySQLServerClient.DoIOAsync(...); 
        // or in Parallel...
        // await Task.WhenAll(myWcfClientProxy.DoIOAsync(...), mySQLServerClient.DoIOAsync(...));
        return true;
    }
