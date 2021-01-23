    Type GetTypeByName(IServiceProvider provider, string typeName)
    {
        var svc= (ITypeResolutionService)provider.GetService(typeof(ITypeResolutionService));
        return svc.GetType(typeName);
    }
    private List<Type> GetAllTypes(IServiceProvider provider)
    {
        var svc= (ITypeDiscoveryService)provider.GetService(typeof(ITypeDiscoveryService));
        return svc.GetTypes(typeof(object), true).Cast<Type>().ToList();
    }
