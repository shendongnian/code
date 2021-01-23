    public class SendEmailService
    {
        private readonly SmtpEmailSetting _smtpEmailSetting;
        public SendEmailService(IOptions<SmtpEmailSetting> smtpOptions )
        {
            _smtpEmailSetting = smtpOptions.Value;
        }
        public void SendEmail()
        {
            var fromEmail = _smtpEmailSetting.SenderEmail;
            var displayName = _smtpEmailSetting.SenderFrom;
        }
    }
