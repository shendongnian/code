    public class EventLogger : BaseLogger
    {  
        public EventLogger()
        {
            //initialize the eventlog, etc
        }
        public override void LogException(Exception ex)
        {
            var string = GetStringFromException(ex);
            EventLog.WriteEntry(...);
        }
        public override void LogException(Exception ex)
        {
            var string = GetStringFromUserMessage(ex);
            EventLog.WriteEntry(...);
        }
    }
    
