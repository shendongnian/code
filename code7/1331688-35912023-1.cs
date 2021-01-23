    public class ProxyClass
    {
        private Localservice _localService;
        private Amazonservice _amazonService;
        public ProxyClass(Localservice instance1, Amazonservice instance2)
        {
            _localService = instance1;
            _amazonService = instance2;
        }
        public void CallMethod()
        {
            if (shouldUseLocalService)
                _localService.CallMethod();
            else
                _amazonService.CallMethod();
        }
    }
