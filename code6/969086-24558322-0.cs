    public interface IPlugin
    {
        void Start();
    }
    
    // You can change this support loading based on dll file name
    public void Load(string fullAssemblyName)
    {
        var assembly = System.Reflection.Assembly.Load(fullAssemblyName);
        var pluginType = assembly.GetTypes().FirstOrDefault(t => t.GetInterfaces().FirstOrDefault() == typeof(IPlugin));
        
        // Concrete class implementing IPlugin must have default empty constructor
        // for following instance creation to work
        var plugin = Activator.CreateInstance(pluginType) as IPlugin;
        plugin.Start();
    }
