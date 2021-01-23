    public interface IConfigurationContextFactory
    {
        IConfigurationContext CreateContext();
    }
    
    // ...
    public ConfigurationContext CreateContext()
    {
        return new ConfigurationContext(connectionString);
    }
