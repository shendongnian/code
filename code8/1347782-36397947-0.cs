    class Thing
    {
        private IExternalService _externalService;
        public Thing(IExternalService externalService)
        {
            _externalService = externalService;
        }
        public void A() { ... }
        public void D(string foo) 
        { 
            _externalService.DoSomeStuff();
        }
    }
