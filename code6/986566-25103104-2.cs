    public class NInjectInstanceProvider : IInstanceProvider, IContractBehavior
    {
        private readonly IKernel kernel;
        public NInjectInstanceProvider(IKernel kernel)
        {
            if (kernel == null) throw new ArgumentNullException("kernel");
            this.kernel = kernel;
        }
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            //delegate to GetInstance(InstanceContext)
            return GetInstance(instanceContext);
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            //resolve the service instance
            return kernel.Get(instanceContext.Host.Description.ServiceType);
        }
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            kernel.Release(instance);
        }
    
        public void AddBindingParameters(ContractDescription contractDescription, 
            ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
    
        public void ApplyClientBehavior(ContractDescription contractDescription,
            ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }
  
        public void ApplyDispatchBehavior(ContractDescription contractDescription,
            ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }
    
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
    }
