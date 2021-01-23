    public class ValidatingConfigurationReader : IConfigurationReader
    {
        private readonly IConfigurationReader reader;
        private readonly ILogger logger;
    
        public ValidatingConfigurationReader(IConfigurationReader reader, ILogger logger)
        {
            this.reader = reader;
            this.logger = logger;
        }
    
        public MyConfiguration ReadConfigValues(string filePath)
        {
            var config = this.reader.ReadConfigValues(filePath);
    
            if (config.OptionalValue == null)
            {
                this.logger.Warn("Optional value not set!");
            }
    
            return config;
        }
    }
