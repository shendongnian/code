    public class EmailController : Controller
    {
        private readonly IOptions<EmailSettings> emailSettings;
    
        public EmailController (IOptions<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings;
        }
    
        public IActionResult Index()
        {
            string apiKey = emailSettings.Options.EmailApiKey;
            ...
        }
    }
