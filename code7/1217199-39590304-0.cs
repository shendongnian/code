    public static class TestDependencies
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            // create container with the runtime dependencies
            var builder = Dependencies.CreateContainerBuilder();
    
            //TODO: add customizations, stubs required for testing
    
            //auto-reg all types from our assembly
            //builder.RegisterAssemblyTypes(typeof(TestDependencies).Assembly).SingleInstance();
            
            //auto-reg all [Binding] types from our assembly
            builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();
                 
            return builder;
        }
    }
