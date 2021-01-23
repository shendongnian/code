    public class GenericInput<T> : IBasicInput<T> where T : InputOutputConfig
    {
        ConfigurationDictionary<T> configuration;
    
        public GenericInput()
        {
            configuration = null;
        }
    
        public void Configure<T2>(ConfigurationDictionary<T2> _conf) where T2 : InputOutputConfig
        {
            // in this line, you need the class template T, not the inner T2
            configuration = new ConfigurationDictionary<T>();
            foreach (KeyValuePair<string,T2> kvp in _conf)
            {
    
            }
        }
    }
