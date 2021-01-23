    public class NotifyController : Controller
    {
        private static IEmailSender emailSender = null;
        protected static ISessionService session = null;
        protected static IMyContext dbContext = null;
        protected static IHostingEnvironment hostingEnvironment = null;
        public NotifyController(
                    IEmailSender mailSenderService,
                    IMyContext context,
                    IHostingEnvironment env,
                    ISessionService sessionContext)
        {
            emailSender = mailSenderService;
            dbContext = context;
            hostingEnvironment = env;
            session = sessionContext;
        }
    }
