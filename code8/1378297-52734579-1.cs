    public class UserLogger
    {
        private readonly Logger _log;
        private readonly User _user;
        public UserLogger(User u)
        {
            _user = u;
            _log = LogManager.GetCurrentClassLogger();
        }
        public void Error(string message)
        {
            LogEventInfo logEvent = 
                     new LogEventInfo(LogLevel.Error, _log.Name, message);
            logEvent.Properties["UserId"] = _user.Id;
    
            _log.Log(logEvent);
        }
    }
    
