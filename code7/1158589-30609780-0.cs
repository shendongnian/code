    public class FooService
    {
        private readonly AppSettings _settings;
    
        public FooService(IOptions<AppSettings> options)
        {
            _settings = options.Options;
        }
        ....
        ....
    }
