        public class SomeController
    {
        private string _endpointUrl;
        public SomeController(IOptions<ConfigurationOptions> options)
        {
            _endpointUrl = options.Options.EndpointUri;
        }
    }
