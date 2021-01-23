    public class DependenyInitializer
    {
       public static readonly DependenyInitializer Instance = new DependenyInitializer();
          private DependenyInitializer()
            {
              var builder = new ContainerBuilder();
              builder.RegisterModule<BusinessLayerModule>();
              builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
              this.Container = builder.Build();
            }
    public IContainer Container { get; }
    }
