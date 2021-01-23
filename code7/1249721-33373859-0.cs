    public class ScanningModule : Module
    {
      private IEnumerable<Assembly> _assemblies;
      public ScanningModule(IEnumerable<Assembly> assemblies)
      {
        this._assemblies = assemblies;
      }
      protected override void Load(ContainerBuilder builder)
      {
        builder.RegisterAssemblyTypes(this._assemblies)...
      }
    }
