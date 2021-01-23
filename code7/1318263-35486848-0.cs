    public class ProxyConfiguration : ConfigurationSection
    {
        private static readonly ProxyConfiguration Config = ConfigurationManager.GetSection("proxy") as ProxyConfiguration;
        public static ProxyConfiguration Instance
        {
            get
            {
                return Config;
            }
        }
        [ConfigurationProperty("autoDetect", IsRequired = true, DefaultValue = true)]
        public bool AutoDetect
        {
            get { return (bool)this["autoDetect"]; }
        }
      // all other properties
    }
