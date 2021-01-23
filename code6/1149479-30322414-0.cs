    public bool GetCriticalErrors(string logEntry)
    {       
        return logEntry.ToUpper().Contains("Error=\"Device Not Found\"".ToUpper());
    }
    //If you want to check in list of string
    public bool GetCriticalErrors(List<string> logEntries)
    {       
		var errorStr = "Error=\"Device Not Found\"".ToUpper();
        return logEntries.Any(l => l.ToUpper().Contains(errorStr));
    }
