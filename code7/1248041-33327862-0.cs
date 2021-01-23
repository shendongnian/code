	public class MyServiceHostFactory : ServiceHostFactory{
	 protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses ) {
		ServiceHost host = new ServiceHost(typeof(HelloService ));
		// add/modify the endpoints, Behaviors, ... through  
        // host.Description.Endpoints, host.Description.Behaviors …
		return host;
	 }
	}
