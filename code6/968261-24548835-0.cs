    public static void Error(string workName, string message, string logcontext, string exMessage = "")
    {
        LogEventInfo logEvent = new LogEventInfo(LogLevel.Error, logcontext, message + (!string.IsNullOrEmpty(exMessage) ? ": " : string.Empty) + exMessage);
        logEvent.Properties["workName"] = workName;
        logger.Log(typeof(InternalLogger), logEvent);
    }
