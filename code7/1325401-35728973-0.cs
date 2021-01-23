    public class StatusBaseClass
    {
        public List<StatusNotification> StatusNotifications;
    }
    public class QuoteStatus : StatusBaseClass
    {
    }
    public class SystemStatus : StatusBaseClass
    {
    }
    public class StatusNotification
    {
    }
    public class QuoteStatusNotification : StatusNotification
    {
    }
    public class SystemtatusNotification : StatusNotification
    {
    }
