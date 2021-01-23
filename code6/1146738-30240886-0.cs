    private static long TimeProcess(String name)
    {
        Process process = new Process();
        process.StartInfo.FileName = name;
    
        process.Start();
        process.WaitForExit();
    
        return (process.EndTime- process.StartTime).TotalMilliseconds;
    }
