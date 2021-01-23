    public class PluginHost : IPluginHost, IPlugin
    {
        private IPlugin _wrapped;
        void IPluginHost.Load(string filename, string typename)
        {
            // load the assembly (filename) into the AppDomain.
            // Activator.CreateInstance the typename to create 3rd party plugin
            // _wrapped = the plugin instance
        }
    
        void IPlugin.DoWork()
        {
            try
            {
                _wrapped.DoWork();
            }catch(Exception ex)
                // log
                // unload plugin whatevs
            }
    }
