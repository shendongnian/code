    var tasks = new Task[] {
        TaskOperationOne(),
        TaskOperationTwo()
    };
    Task.WaitAll(tasks);
    // or
    await Task.WhenAll(tasks);
