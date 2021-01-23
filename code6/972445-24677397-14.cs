    public class MyServiceClient: IMyService, IDisposable
    {
        DuplexChannelFactory<IMyService> myServiceFactory { get; set; }
        public MyServiceClient(IMyServiceCallback Callback)
        {
            InstanceContext site = new InstanceContext(Callback);
            NetNamedPipeBinding binding = new NetNamedPipeBinding();
            EndpointAddress endpointAddress = new EndpointAddress(Constants.myPipeService + @"/" + Constants.myPipeServiceName);
            myServiceFactory = new DuplexChannelFactory<IMyService>(site, binding, endpointAddress);
        }
        public void DoWork()
        {
            myServiceFactory.CreateChannel().DoWork();
        }
        public void Dispose()
        {
            myServiceFactory.Close();
        }
    }
