        public class SomeController
    {
        private DocumentDbRepository _documentDbRepositoy
        public SomeController(IOptions<ConfigurationOptions> options)
        {
            _documentDbRepositoy = new DocumentDbRepository (options.Options.EndpointUri);
        }
    }
