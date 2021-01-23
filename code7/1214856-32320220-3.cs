	protected string _propertiesJson;
	public string PropertiesJson
	{
		get {
			return JsonConvert.SerializeObject(Properties);
		}
		set {
			_propertiesJson = value;
			Properties = JsonConvert.DeserializeObject<Dictionary<string, object>>(value);
		}
	}
	protected Dictionary<string, object> _properties;
	public Dictionary<string, object> Properties
	{
	    get 
	    {
	    	if (_properties != null)
	    	{
	    		return _properties;
	    	}
	    	else if (string.IsNullOrEmpty(_propertiesJson))
	    	{
	    		return JsonConvert.DeserializeObject<Dictionary<string, object>>(_propertiesJson);
	    	}
	    	else
	    	{
	    		return null;
	    	}
	    }
	    set 
	    { 
	    	_properties = value; 
	    }
	}
