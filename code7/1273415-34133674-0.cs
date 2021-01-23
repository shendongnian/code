    public class CompositionRootSettings {
    	
    	public string Something { get; set; }
    	
    }
    
    public interface IServicePackage
    {
    	void RegisterServices(Container container, CompositionRootSettings settings);
    }
    
    public static void RegisterServicePackages(this Container container, CompositionRootSettings settings)
    {
    	var packages = from assembly in AppDomain.CurrentDomain.GetAssemblies()
    				   from type in assembly.GetTypes()
    					where typeof(IServicePackage).IsAssignableFrom(type)
    					where !type.IsAbstract
    					select (IServicePackage)Activator.CreateInstance(type);
    
    	packages.ToList().ForEach(p => p.RegisterServices(container, settings));
    }
