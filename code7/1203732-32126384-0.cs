    var implementationTypes = container.GetTypesToRegister(typeof(IBaseService),
        AppDomain.CurrentDomain.GetAssemblies());
    foreach (Type implementationType in implementationTypes)
    {
        Type serviceType = implementationType.GetInterfaces()
            .Where(i => i != typeof(IBaseService));
            .Single();
        container.Register(serviceType, implementationType, Lifestyle.Scoped);
    }
