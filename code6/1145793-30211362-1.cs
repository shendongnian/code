    private readonly ConcurrentDictionary<string,bool> _workingWithFile = new ConcurrentDictionary<string,bool>();
    public static void LogDataContractToFile(string XMLStringToLog, string filePathAndName)
    {
        ...
        lock (LogDataContractToFileLock)
        {
            ...
            
            while(!_workingWithFile.TryAdd(filePathAndName, true))
            {
                Thread.Sleep(1000);
            }
            ...
            try
            {
                ...
            }
            finally
            {
                //Perhaps check the result here.
                bool result;
                _workingWithFile.TryRemove(filePathAndName, out result);
            }
        }
    }
