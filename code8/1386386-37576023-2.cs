    try
    {
        Parallel.ForEach(collection, item =>
        {
            if (error)
            {
                throw new Exception();
            }
        });
    }
    catch (AggregateException ex)
    {
        foreach (var exception in ex.InnerExceptions)
        {
            // do something       
        }
    }
