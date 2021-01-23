    var concurrentScanList = new ConcurrentQueue<Computer>(computersToScan);
    var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
    var taskArray = new Task[20];
    
    //Initializing the tasks
    for (var index = 0; index < taskArray.Length; index++)
    {
        taskArray[index] = taskFactory.StartNew(() =>
        {
            Computer host;
            while (concurrentScanList.TryDequeue(out host))
            {
                DoSomething(host);
            }
        });
    }
    
    //Wait for all tasks to finish - queue will be empty then
    Task.WaitAll(baseProcessorTaskArray);
 
