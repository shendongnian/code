    public async Task BulkExecution()
    {
        //Some code            
        Task[] tasks = Machines.Select(machine =>
        {
            //more code to work out the CMDline and other duties.
            return Task.Run(r => ExecutePsexec(CMDLine, ExecutionTimeoutMsec));
        }).ToArray();
        await Task.WhenAll(tasks);
        //More Code
    }
