    try
    {
        using (IConnection conn = ...)
        {
        }
    }
    catch (Exception exc) // !!! Catching Exception and not something more specific may become a source of problems
    {
        // Handle errors
    }
