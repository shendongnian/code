    try
    {
        await Task.WhenAll(tasks);
    }
    catch (Exception ex)
    {
        DebugLogger.Write("uh oh.. it died");
    }
