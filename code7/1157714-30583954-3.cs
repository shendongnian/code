    public class CustomConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public MyConfigElementCollection ConfigElementCollection
        {
            get
            {
                return (MyConfigElementCollection)base[""];
            }
        }
    }
