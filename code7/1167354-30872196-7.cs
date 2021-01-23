    public class ApplicationManager
    {
    	private WcfHost _bulkRulesWcfHost;
    	
    	public void Start()
    	{
    		// ...
    		SetupWcf();				
    	}
    
    	public void Stop()
    	{
    		// ...				
    		if (_bulkRulesWcfHost != null) 
    			_bulkRulesWcfHost.Stop();
    	}
    
    	private void SetupWcf()
    	{
    		// you can have many WCF services here		
    		// ...
    		
    		IBulkRules syncService = new BulkRulesService(...);
    		_bulkRulesWcfHost = new WcfHost(syncService, "BulkRulesService");
    		_bulkRulesWcfHost.Start();
    	}
    }
