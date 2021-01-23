    class ConfigFile
    {
        private Dictionary<string, string> _configDictionary;
        public ConfigFile(Dictionary<string, string> configValues)
        {
            _configDictionary = configValues;
        }
        public string ServerAddress
        {
            get { return PullValueFromConfig("serveraddress", "192.168.1.1"); }
        }
        public string ServerPort
        {
            get { return PullValueFromConfig("serverport", "80"); }
        }
        public string ServerTimeout
        {
            get { return PullValueFromConfig("servertimeout", "900"); }
        }
        private string PullValueFromConfig(string key, string defaultValue)
        {
                string value;
                if (_configDictionary.TryGetValue(key, out value))
                    return value;
                return defaultValue;
        }
    }
