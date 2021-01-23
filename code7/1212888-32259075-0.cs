    protected override IEnumerable<object> GetAllInstances(Type service)
    {
        IServiceProvider provider = ContainerInstance;
        Type collectionType = typeof(IEnumerable<>).MakeGenericType(service);
        var services = (IEnumerable<object>)provider.GetService(collectionType);
        return services ?? Enumerable.Empty<object>();
	}
