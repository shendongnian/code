    public class EmailHelper : IEmailHelper
    {
        private readonly IConfiguration _configuration;
    
        public EmailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    
        public void SendEmail(string from, string to, string subject, string message)
        {
            MailMessage msg = new MailMessage(from, to, subject, body);
            var client = new SmtpClient(_configuration.GetConfigurationValue("smpthost")); //this will be moved to config.
            client.Send(msg);
        }
    }
