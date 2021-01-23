    public class VCRklServiceAdapter : IRklService
    {
    	private readonly string _hostname;
    	private readonly int _port;
    	private readonly IHsmLogger _logger;
    	private readonly AppDomain _instanceDomain;
    	private readonly IRklServiceRuntime _rklServiceRuntime;
    
    	public Guid ClientId { get; }
    
    	public VCRklServiceAdapter(
    		string hostname, 
    		int port,  
    		IHsmLogger logger)
    	{
    		Ensure.IsNotNullOrEmpty(hostname, nameof(hostname));
    		Ensure.IsNotDefault(port, nameof(port), failureMessage: $"It does not appear that the port number was actually set (port: {port})");
    		Ensure.IsNotNull(logger, nameof(logger));
    
    		ClientId = Guid.NewGuid();
    
    		_logger = logger;
    		_hostname = hostname;
    		_port = port;
    
    		// configure the domain
    		_instanceDomain = AppDomain.CreateDomain(
    			$"vc_rkl_instance_{ClientId}",
    			null, 
    			AppDomain.CurrentDomain.SetupInformation);
    
    		// using the configured domain, grab a command instance from which we can
    		// marshall in some data
    		_rklServiceRuntime = (IRklServiceRuntime)_instanceDomain.CreateInstanceAndUnwrap(
    			typeof(VCServiceRuntime).Assembly.FullName,
    			typeof(VCServiceRuntime).FullName);
    	}
    	
    	public RklResponse GetKeys(RklRequest rklRequest)
    	{
    		Ensure.IsNotNull(rklRequest, nameof(rklRequest));
    
    		var response = _rklServiceRuntime.Run(
    			rklRequest, 
    			_hostname, 
    			_port, 
    			ClientId, 
    			_logger);
    
    		return response;
    	}
    
    	/// <summary>
    	/// Releases unmanaged and - optionally - managed resources.
    	/// </summary>
    	public void Dispose()
    	{
    		AppDomain.Unload(_instanceDomain);
    	}
    }
