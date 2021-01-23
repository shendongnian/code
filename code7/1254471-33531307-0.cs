    public class GmailSection : ConfigurationSection
    {
        [ConfigurationProperty("server")]
        public ServerElement Server
        {
            get
            {
                return (ServerElement)this["server"];
            }
            set
            {
                this["server"] = value;
            }
        }
        [ConfigurationProperty("from")]
        public FromElement From
        {
            get
            {
                return (FromElement)this["from"];
            }
            set
            {
                this["from"] = value;
            }
        }
    }
