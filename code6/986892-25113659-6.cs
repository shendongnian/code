    LogLog.LogReceived += (s, e) =>
    {
        if (e.LogLog.Prefix.Contains("ERROR"))
        {
            throw new ConfigurationErrorsException(e.LogLog.Message,
                e.LogLog.Exception);
        }
    };
