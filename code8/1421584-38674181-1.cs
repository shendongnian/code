    public class DomainModule : Module
    {
    
        protected override void Load(ContainerBuilder builder)
          {
            base.Load(builder);
    
            builder.RegisterType<Library>()
            .AsImplementedInterfaces()
            .SingleInstance();
          }
    }
