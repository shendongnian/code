    public static class DocumentDbRepository<T> : IDocumentDbRepository<T>
    {
        private string EndpointUri { get; private set;}
    
        public DocumentDbRepository(IOptions<ConfigurationOptions> options){
            EndpointUri = options.Options.EndpointUri;
        }
    
        //...
    
    
    }
