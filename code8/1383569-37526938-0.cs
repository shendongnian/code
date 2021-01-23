    class ServiceHostNoConfig<S> : ServiceHost where S : class
    {
        public ServiceHostNoConfig(string address)
        {
            UriSchemeKeyedCollection c = new UriSchemeKeyedCollection(new Uri(address));
            InitializeDescription(typeof(S), c);
        }
    
        public new void InitializeDescription(Type serviceType, UriSchemeKeyedCollection baseAddresses)
        {
            base.InitializeDescription(serviceType, baseAddresses);
        }
    
        protected override void ApplyConfiguration()
        {
        }
    }
