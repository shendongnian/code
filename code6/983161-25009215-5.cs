    _cts.Cancel();
    try
    {
        Task.WaitAll(_workers.ToArray()); 
    }
    catch (AggregateException ex) 
    {
        ex.Handle(inner => inner is OperationCanceledException);
    }
    
