    ServiceHost host =
       new ServiceHost(typeof(ServiceHelloWorld), new Uri[] { });
    host.AddServiceEndpoint(typeof(IPublicInterface), 
       new NetTcpBinding(), "net.tcp://localhost:7000/publicinterface");
    host.AddServiceEndpoint(typeof(ILocalInterface), 
       new NetNamedPipeBinding(), "net.pipe://localhost:8000/privateinterface");
