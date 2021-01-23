    public void LogEntry(string line)
    {
        string[] values = line.Split(',');
        Id = values[0],
        Service = values[1],
        Name = values[2],
        Process = values[3],
        type = values[4]
        [...]    
    }
