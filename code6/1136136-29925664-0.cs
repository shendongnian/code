        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple, AddressFilterMode = AddressFilterMode.Any)]
    public partial class MyServiceContract :IMyServiceContract,IChannelInitializer, IContractBehavior
    {
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            
        }
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            
        }
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.ChannelDispatcher.ChannelInitializers.Add(this);
        }
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            
        }
        public void Initialize(System.ServiceModel.IClientChannel channel)
        {
           channel.Closed += new EventHandler(client_Disconnected);
        }
        private void client_Disconnected(object sender, EventArgs e)
        {
           IClientChannel channel =(IClientChannel)sender;
           // free your resources here
        }
    }
  
