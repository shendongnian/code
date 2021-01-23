    public class WcfHost
    {
    	private readonly ServiceHost _serviceHost;
    
    	public WcfHost(object service, string name)
    	{
    		if (service == null) throw new ArgumentNullException("service");
    		if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
    
    		_serviceHost = new ServiceHost(service);
    		Name = name;
    	}
    
    	public string Name { get; private set; }
    
    	public void Start()
    	{
    		if (_serviceHost != null)
    			_serviceHost.Open();
    	}
    
    	public void Stop()
    	{
    		if (_serviceHost != null)
    			_serviceHost.Close();
    	}
    }
