    class AppConfigEmailSettings : IEmailSettings {
        public AppConfigEmailSettings() {
            this.Server = ConfigurationManager.AppSettings["server"];
            this.Sender = ConfigurationManager.AppSettings["sender"];
            this.Recipients = ConfigurationManager.AppSettings["recipients"].Split(';');
        }
    
        public string Server { get; private set; }
        public string Sender { get; private set; }
        public string[] Recipients { get; private set; }
    }
