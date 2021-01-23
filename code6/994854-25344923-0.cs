    // the contract
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        int Foo( int bar );
    }
    
    // the implementation
    public MyService : IMyService
    {
        public int Foo( int bar ){ return bar * 100; }
    }
    // hosting the service within your application
    var baseUri = new Uri( "net.tcp://localhost:59999/" );
    var serviceHost = new ServiceHost( typeof( MyService ), baseUri );
   
    // many options can/should be set here, e.g. throttling, security, and serialization behavior
    var binding = new NetTcpBinding();
    var endpoint = serviceHost.AddServiceEndpoint( typeof( IMyService ), binding, baseUri );
