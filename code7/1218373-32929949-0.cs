    public abstract class AddInResolutionTestBase:ResolutionTestBase
    {
      private CompositionContainer _container;
      private IModuleCatalog _moduleCatalog;
      private IEnumerable<object> _testEntities;
      private IEnumerable<ModuleInfo> _testModuleInformation;
      static AddInResolutionTestBase()
      {
        Logger = new EmptyLogger();
      }
      [TestInitialize]
      public virtual void TestInitialise()
      {
        // Create MEF catalog.
        AggregateCatalog = CreateAggregateCatalog();
        ConfigureAggregateCatalog();
        AggregateCatalog = DefaultPrismServiceRegistrar.RegisterRequiredPrismServicesIfMissing(AggregateCatalog);
        ConfigureContainer();
        // Initialise modules to be tested.
        CompositionContainer.GetExportedValue<IModuleManager>().Run();
      }
      #region Protected Methods
      protected virtual void ConfigureAggregateCatalog()
      {
        var testAssemblies = TestEntities.OfType<Assembly>();
        foreach (var testAssembly in testAssemblies)
        {
          AggregateCatalog.Catalogs.Add(new AssemblyCatalog(testAssembly));
        }
        if (TestEntities.Any(entity => entity is System.Type))
        {
          var catalog = new TypeCatalog(TestEntities.OfType<System.Type>());
          AggregateCatalog.Catalogs.Add(catalog);
        }
      }
      protected virtual void ConfigureContainer()
      {
        CompositionContainer.ComposeExportedValue<ILoggerFacade>(Logger);
        CompositionContainer.ComposeExportedValue<IModuleCatalog>(ModuleCatalog);
        CompositionContainer.ComposeExportedValue<IServiceLocator>(new MefServiceLocatorAdapter(CompositionContainer));
        CompositionContainer.ComposeExportedValue<AggregateCatalog>(AggregateCatalog);
      }
      protected virtual AggregateCatalog CreateAggregateCatalog()
      {
        return new AggregateCatalog();
      }
      protected virtual CompositionContainer CreateContainer()
      {
        return new CompositionContainer(AggregateCatalog);
      }
      protected virtual IModuleCatalog CreateModuleCatalog()
      {
        return new ModuleCatalog(TestModuleInformation);
      }
      protected abstract IEnumerable<object> GetTestEntities();
      protected abstract IEnumerable<ModuleInfo> GetTestModuleInformation(); 
      #endregion
      #region Protected Properties
      protected AggregateCatalog AggregateCatalog { get; set; }
      protected CompositionContainer CompositionContainer
      {
        get { return _container ?? (_container = CreateContainer()); }
      }
      protected static ILoggerFacade Logger { get; private set; }
      protected IModuleCatalog ModuleCatalog
      {
        get { return _moduleCatalog ?? (_moduleCatalog = CreateModuleCatalog()); }
      }
      protected IEnumerable<object> TestEntities
      {
        get { return _testEntities ?? (_testEntities = GetTestEntities()); }
      }
      protected IEnumerable<ModuleInfo> TestModuleInformation
      {
        get { return _testModuleInformation ?? (_testModuleInformation = GetTestModuleInformation()); }
      } 
      #endregion
    }
