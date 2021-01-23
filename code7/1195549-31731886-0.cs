    var nrOfTasks = ... ;
    ConcurrentDictionary<int, ResultType> Results = new ConcurrentDictionary<int, ResultType>();
    var barrier = new Barrier(nrOfTasks, (b) =>
    {
        // here goes the work of TaskA
        // and immediatley
        // here goes the work of TaskB, having the results of TaskA and any other task you might need
    });
    
    Task.Run(() => { Results[1] = Task1.Result; barrier.SignalAndWait(); }, ct),
    ...
    Task.Run(() => { Results[nrOfTasks] = Taskn.Result; barrier.SignalAndWait(); }, ct
    
