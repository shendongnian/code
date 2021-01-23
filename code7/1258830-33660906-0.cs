    private async Task<ProcessResult> processTask(ProcessTask task) 
    {
        // do something intensive with data
    }
    
    private IEnumerable<ProcessTask> GetOutstandingTasks() 
    {
        // retreive some tasks from db
    }
    
    private void ProcessAllData()
    {
        List<Task<ProcessResult>> taskQueue = 
            GetOutstandingTasks()
            .Select(tsk => processTask(tsk))
            .ToList(); // grab initial task queue
        while(taskQueue.Any()) // iterate while tasks need completing
        {
            Task<ProcessResult> firstFinishedTask = await Task.WhenAny(taskQueue); // get first to finish
            taskQueue.Remove(firstFinishedTask); // remove the one that finished
            ProcessResult result = await firstFinishedTask; // get the result
            // do something with task result
            taskQueue.AddRange(GetOutstandingTasks().Select(tsk => processData(tsk))) // add more tasks that need performing
        }
    }
