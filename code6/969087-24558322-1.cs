    public interface IPlugin
    {
        void Start();
    }
    
    // You can change this to support loading based on dll file name
    // Use one of the other available Assembly load options
    public void Load(string fullAssemblyName)
    {
        var assembly = System.Reflection.Assembly.Load(fullAssemblyName);
        // Assuming only one class implements IPlugin 
        var pluginType = assembly.GetTypes()
                   .FirstOrDefault(t => t.GetInterfaces()
                   .Any(i=> i == typeof(IPlugin)));
        
        // Concrete class implementing IPlugin must have default empty constructor
        // for following instance creation to work
        var plugin = Activator.CreateInstance(pluginType) as IPlugin;
        plugin.Start();
    }
