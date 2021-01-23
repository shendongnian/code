    public class MySettings : ConfigurationSection
    {
        /// <summary>
        /// Some setting description here...
        /// </summary>
        [ConfigurationProperty("setting1",
            DefaultValue = false,
            IsRequired = true)]
        public bool Setting1
        {
            get { return (bool)this["setting1"]; }
        }
    }
    public class Foo
    {
        public static MySettings GetSettings()
        {
            // Load settings from your configuration.
            return ConfigurationManager.GetSection("mySettings") as MySettings;
        }
    }
