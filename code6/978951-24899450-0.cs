    public class TestClassModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<Widget>().As<IWidget>();
            builder.RegisterGeneratedFactory<WidgetFactory.Create>(new TypedService(typeof(IWidget)));
            builder.RegisterType<FoobarUser>();
        }
    }
