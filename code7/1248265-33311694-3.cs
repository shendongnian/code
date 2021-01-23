    public class YahooClient : MailClient<YahooMessage>
    {
        private YahooConfiguration configuration = new YahooConfiguration();
        public YahooClient (string username, string password) 
            : base(new YahooAuthentication(username, password)) 
        { 
        }
        public override List<YahooMessage> GetMessages()
        {
            //Code for retrieving emails
        }
        public override State SendMessage(YahooMessage message)
        {
            //Code for sending emails
        }
    }
