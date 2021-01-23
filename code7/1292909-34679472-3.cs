    private static ICommunicator Proxy;
    ServiceEndpoint endpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(ICommunicator)))
    {
       Address = new EndpointAddress("net.pipe://localhost/CommunicatorService"),
       Binding = new NetNamedPipeBinding()
    };
    Proxy = (new DuplexChannelFactory<ICommunicator>(new InstanceContext(this), endpoint)).CreateChannel();
    ((IClientChannel)Proxy).Open();
    public void StartServer(string serverData)
    {
        string serverStartResult = Proxy.StartServer(serverData); // calls the method I showed above
    }
