    public class Log4netAdapter: ILogger
    {
        private readonly log4net.ILog m_Adaptee;
        public Log4netAdapter(log4net.ILog adaptee)
        {
            m_Adaptee = adaptee;
        }
        public void Log(LogEntry entry)
        {
            //Here invoke m_Adaptee
            if(entry.LoggingEventType == LoggingEventType.Information)
                m_Adaptee.Info(entry.Message);
            ...
        }
    }
