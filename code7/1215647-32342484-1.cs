    public class Log4netAdapter : ILogger
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
                m_Adaptee.Info(entry.Message, entry.Exception);
            else if(entry.LoggingEventType == LoggingEventType.Warning)
                m_Adaptee.Warn(entry.Message, entry.Exception);
            else if(entry.LoggingEventType == LoggingEventType.Error)
                m_Adaptee.Error(entry.Message, entry.Exception);
            else
                m_Adaptee.Fatal(entry.Message, entry.Exception);
        }
    }
