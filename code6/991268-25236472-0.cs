    class PluginProvider
    {
        private bool _isInitialized;
        IEnumerable<IPluginType> PluginTypes { get; set;}
    
        public void Initialize()
        {
            if (_isInitialized)
            {
                 return;
            }      
            InitializePlugins();
            _isInitialized = true;  
        }
    }
