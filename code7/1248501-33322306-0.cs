    using System.Linq;
    using System.Reflection;
        
    List<Type> properties = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "YourClassNameSpace");
    
     var propertiesNames = properties.Select(p => p.Name);
        
    private List<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
    {
        return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToList();
    }
