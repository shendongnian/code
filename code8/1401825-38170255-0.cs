    IUnityContainer container = new UnityContainer();
    container.RegisterTypes(
        AllClasses.FromAssembliesInBasePath().Where(
        t => t.Namespace.StartsWith("Framework.RepositoryImplementations") ||
        t.Namespace.StartsWith("Framework.RepositoryInterfaces")),
        WithMappings.FromMatchingInterface,
        WithName.Default,
        WithLifetime.Transient);
    ICustomer result = container.Resolve<ICustomer>();
