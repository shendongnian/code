    // The queue, initialized with a maximum capacity of 25 lines.
    // Increase or decrease depending on your needs.
    private BlockingCollection<string> linesQueue = new BlockingCollection<string>(25);
    // in your Main
    var task1 = Task.Factory.StartNew(() => ProcessLines, TaskCreationOptions.LongRunning);
    var task2 = Task.Factory.StartNew(() => ProcessLines, TaskCreationOptions.LongRunning);
    // The producer reads lines and adds them to the queue
    foreach (var line in File.ReadLines(inputFilename))
    {
        linesQueue.Add(line);
    }
    
    // Tell the queue that no more data is forthcoming.
    linesQueue.CompleteAdding();
    // wait for the consumers to complete
    task1.Wait();
    task2.Wait();
    // and your ProcessRecords method
    void ProcessRecords()
    {
        // do whatever initialization you want here
        foreach (var line in linesQueue.GetConsumingEnumerable())
        {
            // split the line and do what you want with the result
        }
    }
