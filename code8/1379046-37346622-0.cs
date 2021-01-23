    public class ServiceModule : Module 
    {
        protected override void Load(ContainerBuilder builder)
		{
            // "ThisAssembly" means "any types in the same assembly as the module"
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(....
        }
    }
