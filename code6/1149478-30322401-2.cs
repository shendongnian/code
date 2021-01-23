    private IEnumerable<string> errorStrings = new[]
    {
      "Error=\"Device Not Found\"".ToUpper(),
      ...
    };
    public bool GetCriticalErrors(string logEntry)
    {
      var logEntryUpper = logEntry.ToUpper();
      return errorStrings.Any(x => logEntry.Contains(x));
    }
