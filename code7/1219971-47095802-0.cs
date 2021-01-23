    string instrumentationKey = Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY");
    if (!string.IsNullOrEmpty(instrumentationKey))
    {
          // build up a LoggerFactory with ApplicationInsights and a Console Logger
           config.LoggerFactory = new LoggerFactory().AddApplicationInsights(instrumentationKey, null).AddConsole();
           config.Tracing.ConsoleLevel = TraceLevel.Off;
    }
