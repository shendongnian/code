    public class MySettings : ConfigurationSection
    {
        /// <summary>
        /// The domain part of the API base URL.
        /// </summary>
        [ConfigurationProperty("setting1",
            DefaultValue = false,
            IsRequired = true)]
        public bool Setting1
        {
            get { return (bool)this["setting1"]; }
        }
    }
    ConfigurationManager.GetSection("mySettings") as MySettings;
