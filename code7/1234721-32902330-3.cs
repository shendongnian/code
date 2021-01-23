    public Task[] StartProcessing()
    {
		...
        for (int i = 0; i < jobList.Count(); i++)
        {
            tasks[i] = ProcessJob(jobList[i]);
        }
        ...
        return tasks;
    }
	
	//in the MAIN METHOD of your application/process
	var tasks = new SomeMainClass().StartProcessing();
    // do all other stuffs here, and just at the end of process
    Task.WaitAll(tasks);
