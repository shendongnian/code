    public class PluginProvider
    {
       IEnumerable<IPluginType> PluginTypes
       {
          get
          {
            return _pluginTypes;
          }
       }
       public PluginProvider()
       {
          InitializePlugins();
       }
    }
