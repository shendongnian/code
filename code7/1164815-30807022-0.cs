    public abstract class BaseWebServiceLogAppender : AppenderSkeleton
    {
        protected IClientService _clientService;
    
        //Url property is declared with tag in my log4net.config tag
        public string Url { get; set; }
    
        public BaseWebServiceLogAppender()
        {
            InitializeClientService();
        }
    
        protected override void Append(LoggingEvent loggingEvent)
        {
            var log = RenderLoggingEvent(loggingEvent);
            _clientService.SendLog(log);
        }
    
        protected abstract void InitializeClientService();
    }
    
    public class EmailWebServiceLogAppender : BaseWebServiceLogAppender
    {
        protected override void InitializeClientService()
        {
            var smtpClientFactory = new SmtpClientFactory();
            var mailMessageFactory = new MailMessageFactory();
            _clientService = new EmailClientService(smtpClientFactory,mailMessageFactory)
        }
    }
    
    public class SmsWebServiceLogAppender : BaseWebServiceLogAppender
    {
        protected override void InitializeClientService()
        {
            _clientService = new SmSClientService(…);
        }
    }
