    private void SetResources(string filename = ResxFileName)
    {
    	if (_resourceManager == null)
    	{
    		Assembly assembly = System.Reflection.Assembly.Load("App_GlobalResources");
    		_resourceManager = new ResourceManager("Resources." + filename, assembly);
    	}
    }
