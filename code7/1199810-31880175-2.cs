    public class Consumer
    {
    	private IEnumerable<Lazy<IService, ServiceMetadata>> _services;
    	
    	public Consumer(IEnumerable<Lazy<IService, ServiceMetadata>> services)
    	{
    		this._services = services;
    	}
    	
    	public void DoWork(bool applicationState, bool businessState)
    	{
    		// Select the service using LINQ against the metadata.
    		var service =
    			this._services
    				.First(s =>
                           s.Metadata.ApplicationState == applicationState &&
                           s.Metadata.BusinessState == businessState)
    				.Value;
    		
    		// Do whatever work you need with the selected service.
    		Console.WriteLine("Service = {0}", service.GetType());
    	}
    }
