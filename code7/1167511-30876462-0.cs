    if (!Directory.Exists(logPath))
    {
        System.IO.Directory.CreateDirectory(logPath);
    }
    for (short i = 0; i < numberOfLines; i++)
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter(logPath);
        runBrowserThread(i);
    }
