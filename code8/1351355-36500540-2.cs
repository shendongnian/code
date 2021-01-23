    public class DependenyInitializer
    {
       public static readonly DependenyInitializer Instance = new DependenyInitializer();
          private DependenyInitializer()
            {
              var builder = new ContainerBuilder();
              builder.RegisterModule<BusinessLayerModule>(); // register all dependencies that has been set up in that module
              builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
              this.Container = builder.Build();
            }
    public IContainer Container { get; }
    }
