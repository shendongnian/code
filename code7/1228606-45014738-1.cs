    using Autofac;
    using System.Reflection;
    using Module = Autofac.Module;
    // ...
    public class MyConventionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new []
            {
                typeof(MyConventionModule).GetTypeInfo().Assembly,
                typeof(ISomeAssemblyMarker).GetTypeInfo().Assembly,
                typeof(ISomeOtherAssemblyMarker).GetTypeInfo().Assembly
            };
            builder.RegisterAssemblyTypes(assemblies)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
