    public class AutofacLoader
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceProject.ServiceInjector>();
            builder.RegisterModule<LocalTestProject.AutofacModule>();
            Container = builder.Build();
        }
        public static IContainer Container { get; set; }
    }
