    try
    {
        using (new System.Runtime.MemoryFailPoint(1024)) // 1024 megabytes
        {
            // Do processing in memory
        }
    }
    catch (InsufficientMemoryException)
    {
        // Do processing on disk
    }
