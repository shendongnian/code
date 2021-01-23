    class BAdapter : IInterfaceB
    {
        private readonly ServiceA _serviceA;
        public BAdapter(ServiceA serviceA)
        {
            _serviceA = serviceA;
        }
        public IInterfaceB Do() { return _serviceA.Do(); }
    }
