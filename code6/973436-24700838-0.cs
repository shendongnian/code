    public class MyServiceClient: IMyService, IDisposable
    {
        DuplexChannelFactory<IMyService> myServiceFactory { get; set; }
        public MyServiceClient(IMyServiceCallback Callback)
        {
            InstanceContext site = new InstanceContext(Callback);
            NetNamedPipeBinding binding = new NetNamedPipeBinding();
            EndpointAddress endpointAddress = new EndpointAddress(Constants.myPipeService + @"/" + Constants.myPipeServiceName);
            myServiceFactory = new DuplexChannelFactory<IMyService>(site, binding, endpointAddress);
            Init();
        }
        public void Init()
        {
            myServiceFactory.CreateChannel().Init();//EndPointNotFoundException Thrown here
        }
        public void DoWork()
        {
            myServiceFactory.CreateChannel().DoWork();//EndPointNotFoundException Thrown here
        }
        public void Dispose()
        {
            myServiceFactory.Close();
        }
    }
