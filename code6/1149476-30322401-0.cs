    private readonly string errorString = "Error=\"Device Not Found\"".ToUpper();
    public bool GetCriticalErrors(string logEntry)
    {
      return logEntry.ToUpper().Contains(errorString);
    }
