    public static class NLogExtensions
    {
      public static void Log(this Logger logger, string task, LogLevel level, string message)
      {
        var LogEventInfo le = new LogEventInfo(level, logger.Name, message);
        le.Properties["Task"] = task;
        logger.Log(typeof(NLogExtensions), le);
      }
    }
