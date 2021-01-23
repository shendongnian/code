    // Add an appender to a logger
    public static void AddAppender(string loggerName,log4net.Appender.IAppender appender)
    {
         log4net.ILog log = log4net.LogManager.GetLogger(loggerName);
         log4net.Repository.Hierarchy.Logger l =
              (log4net.Repository.Hierarchy.Logger)log.Logger;
    
          l.AddAppender(appender);
    }
