    private static void TaskDesignedRun()
    {
        var expectedParallelQueues = 1024; //Optimize it. I've chosen it randomly
        var parallelProcessingTaskCount = 4 * Environment.ProcessorCount; //Optimize this too.
        var baseProcessorTaskArray = new Task[parallelProcessingTaskCount];
        var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
        var itemsToProcess = new BlockingCollection<MyQueue>(expectedParallelQueues);
        //Start a new task to populate the "itemsToProcess"
        taskFactory.StartNew(() =>
        {
            // Add code to read queues and add them to itemsToProcess
            Console.WriteLine("Done reading all the queues...");
            // Finally signal that you are done by saying..
            itemsToProcess.CompleteAdding();
        });
        //Initializing the base tasks
        for (var index = 0; index < baseProcessorTaskArray.Length; index++)
        {
            baseProcessorTaskArray[index] = taskFactory.StartNew(() =>
            {
                while (!itemsToProcess.IsAddingCompleted && itemsToProcess.Count != 0)           {
                    MyQueue q;
                    if (!itemsToProcess.TryTake(out q)) continue;
                    //Process your queue
                }
             });
         }
         
         //Now just wait till all queues in your database have been read and processed.
         Task.WaitAll(baseProcessorTaskArray);
    }
