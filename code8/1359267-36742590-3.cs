    public abstract class Logger
    {
        public static Logger NLog()
        {
            return new NLogLogger();
        }
    }
    ...
    
    var logger = Logger.NLog();
    logger.Log("Message");
