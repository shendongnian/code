    var exceptions = new ConcurrentQueue<Exception>();
    Parallel.ForEach(items, i => 
    { 
        try
        {
            //Your code to do whatever
        }
        catch(Exception ex)
        {
            exceptions.Enqueue(ex);
        }
    });
