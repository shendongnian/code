    public interface IDatabaseSettings
    {
         string Host { get; set; }
    }
    public interface ISettings 
    { 
         IDatabaseSettings Database { get; }
    }
    public interface ISomeRepository
    {
    }
    
    public class SomeRepositoryImpl : ISomeRepository
    {
        private readonly ISettings _settings;
        
        // Inject Settings as constructor's dependency
        public SomeRepositoryImpl(ISettings settings)
        {
             _settings = settings;
             // Now you can access DatabaseSettings as follows:
             // Settings.Database.Host
        }
    
        public ISettings Settings => _settings;
    }
