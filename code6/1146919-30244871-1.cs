    class GmailEmailConnectorProvider : EmailConnectorProvider
    {
        private string clientSecret;
        public GmailEmailConnectorProvider()
        {
            clientSecret = Settings.ClientSecret;
        }
    }
