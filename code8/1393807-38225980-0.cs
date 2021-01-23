    Type GetTypeFromName(IServiceProvider provider, string typeName)
    {
        var svc= (ITypeResolutionService)provider.GetService(typeof(ITypeResolutionService));
        return svc.GetType(typeName);
    }
