    public class XXXModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<XXXMenuBuilder>()
                   .As<IMenuBuilder>();
        }
    }
