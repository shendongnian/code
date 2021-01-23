    public class ExampleController
    {
        private TestService.Factory _factory;
        public ExampleController(TestService.Factory factory)                
        {
            _factory = factory();
        }
    
        public OtherMethod()
        {
            var serviceInstance = _factory();
        }
    }
