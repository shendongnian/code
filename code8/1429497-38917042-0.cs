    public class Configuration : ConfigurationElement
    {
        [ConfigurationProperty("User", IsRequired = false)]
        public string User
        {
            get { return (string)this["User"]; }
            set { this["User"] = value; }
        }
    }
