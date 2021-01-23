    interface IConfigurationManager
    {
        void Get(ConfigurationKey key);
        void Set(ConfigurationKey key, string value);
    }
    public class ConfigurationKey
    {
        public ConfigurationKey(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
