    public static class DependencyContainer
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
    
            builder.RegisterType<ClassA>().As<IClassA>();
            builder.RegisterType<ClassB>().As<IClassB>().SingleInstance();
            
            builder.Register(c => 
                return new [] { c.Resolve<IClassA>(), c.Resolve<IClassA>() })
                   .As<IEnumerable<IClassA>>();
    
            return builder.Build();
        }
    }
