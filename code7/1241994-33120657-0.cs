    class Application
    {
        private Process _process; 
    
        private static string _applicationPath;
    
        public void Start(string arguments)
        {
    		var isDeployed = string.IsNullOrEmpty(_applicationPath);
            if (!isDeployed)
    		{
                var deployment = new Deployment();
    			_applicationPath = deployment.Deploy();
    		}
            _process = Process.Start(_applicationPath, arguments);
        }
    
        public void SomeMethod()
        {
            //method that manipulate _process
        }    
    }
    
    class Deployment
    {
    	private static string _applicationPath;
    	public string Deploy()
        {
            if (IsDeployed)
            {
                return _applicationPath;
            }
            // copying, installation steps (takes some time) and assign _applicationPath
          
    		return _applicationPath;
        }
    }
