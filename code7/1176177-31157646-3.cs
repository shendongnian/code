    try
    {
        // run some EF query
    }
    catch (EntityCommandExecutionException exception)
    {
        if (!exception.IsInvalidObjectNameError())
        {
            throw;
        }
        // one of the objects referenced by the query is missing
    }
