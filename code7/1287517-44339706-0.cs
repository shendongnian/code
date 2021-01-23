    [Binding]
    public class RestClientInjector
    {
        private readonly IObjectContainer objectContainer;
        public RestClientInjector(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }
        [BeforeScenario]
        public void InitializeRestClient()
        {
            RestClient client = SingletonRestClient.getInstance();
            objectContainer.RegisterInstanceAs<RestClient>(client);
        }
        // implelent singleton
        
        public class SingletonRestClient
        {
            private static RestClient client = new RestClient();
            private SingletonRestClient(IObjectContainer objectContainer) {}
            public static RestClient getInstance()
            {
                return client;
            }
        }
    }
