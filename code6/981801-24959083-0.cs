    public abstract class MailBase
    {
        private SmtpClient _client;
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public MailBase()
        {
             _client = new SmtpClient();
             _client.Port = 25;
             _client.DeliveryMethod = SmtpDeliveryMethod.Network;
             _client.UseDefaultCredentials = false;
             _client.Host = "smtp.google.com";
        }
        protected void SendInternal()
        {
            //Send code
        }
    }
    public class DailyMail : MailBase
    {
        public DailyMail(string to)
        {
             To = to;
             From = "someemail@email.com";
             Subject = "My Subject";
             Body = "My body";
        }
        public void Send()
        {
             SendInternal();
        }
    }
