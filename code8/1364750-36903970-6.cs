    private static IEnumerable<PropertyOrFieldServiceInfo> DeclaredPublicProperties(Request request)
    {
        return (request.ImplementationType ?? request.ServiceType).GetTypeInfo()
            .DeclaredProperties.Where(p => p.IsInjectable())
            .Select(PropertyOrFieldServiceInfo.Of);
    }
 
