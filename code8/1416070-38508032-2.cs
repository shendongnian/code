    //Elsewhere
    private static SemaphoreSlim _fileLock = new SemaphoreSlim(1);
    //In your function.
    try
    {
        await _fileLock.WaitAsync();
        using(var file = new System.IO.StreamWriter(Server.MapPath("~/logs/logs.txt"), true))
        {
            await file.WriteLineAsync("execution started at " + System.DateTime.Now.ToString());
        }
    }
    finally
    {
        _fileLock.Release();
    }
