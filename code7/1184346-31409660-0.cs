    private static ISynchronizeInvoke _invoker = null;
    public static void OnStart()
    {
        _invoker.Invoke((Action)(() => {
            // some log file code here
            if (_pluginManager == null)
            {
                _pluginManager = new PluginManager();
            }
            // some log file code here
            _pluginManager.Show();
            // some log file code here
        }), null);
    }
    
    public static void OnStop()
    {
        if (_pluginManager != null)
        {
            // some log file code here
            _pluginManager.Invoke((Action)(() => _pluginManager.Hide()));
            // some log file code here
        }
    }
