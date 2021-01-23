    public class License
    {
    	[Key]
    	public string LicenseNum { get; set; }
    
    	private License _upgradeTo;
    	private License _upgradedFrom;
    
    
    	public License UpgradeTo
    	{
    		get { return _upgradeTo; }
    		set
    		{
    			_upgradeTo = value;
    			if (_upgradeTo != null && _upgradeTo.UpgradedFrom != this)
    			{
    				_upgradeTo.UpgradedFrom = this;
    			}
    		}
    	}
    
    	public License UpgradedFrom
    	{
    		get { return _upgradedFrom; }
    		set
    		{
    			_upgradedFrom = value;
    			if (_upgradedFrom != null && _upgradedFrom.UpgradeTo != this)
    			{
    				_upgradedFrom.UpgradeTo = this;
    			}
    		}
    	}
    
    	internal License InternalUpgradedTo
    	{
    		get { return UpgradeTo; }
    	}
    
    	internal License InternalUpgradedFrom
    	{
    		get { return UpgradedFrom; }
    	}
    }
