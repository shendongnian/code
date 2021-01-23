    public class PerOperationThrottleBehaviorAttribute : Attribute, IServiceBehavior,IEndpointBehavior
    {
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach(var ep in serviceDescription.Endpoints)
            {
                // add the EndpointBehavior
                ep.EndpointBehaviors.Add(this);
            }      
        }
    
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            // our PerOperationThrottle gets created and wired
            endpointDispatcher.
                DispatchRuntime.
                InstanceContextInitializers.
                Add(new PerOperationThrottle());
        }
    
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {   
        }
        public void Validate(ServiceEndpoint endpoint)
        {   
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        { 
        }
    }
