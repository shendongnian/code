    public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }
    public static void End()
    {
        StructureMapDependencyScope.Dispose();
    }
    public static void Start()
    {
        IContainer container = IoC.Initialize();
        StructureMapDependencyScope = new StructureMapDependencyScope(container);
        DependencyResolver.SetResolver(StructureMapDependencyScope);
        DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
    }
