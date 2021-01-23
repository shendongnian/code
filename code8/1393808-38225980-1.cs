    private List<Type> GetProjectTypes(IServiceProvider provider)
    {
        var svc= (ITypeDiscoveryService)provider.GetService(typeof(ITypeDiscoveryService));
        return svc.GetTypes(typeof(object), true).Cast<Type>().ToList();
    }
