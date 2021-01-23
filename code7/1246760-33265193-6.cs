    public class CustomExtension : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new CustomBehavior();
        }
    
        public override Type BehaviorType
        {
            get
            {
                return typeof(CustomBehavior);
            }
        }
    }
    public class CustomBehavior : IServiceBehavior
    {
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription,
        ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
            {
                foreach (var endpoint in dispatcher.Endpoints)
                {
                    endpoint.DispatchRuntime.MessageInspectors.Add(new CustomInterceptor());
                }
            }
        }
    
        public void AddBindingParameters(ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }
    
        public void Validate(ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase)
        {
        }
    }
