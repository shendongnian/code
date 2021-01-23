    builder.RegisterGeneric(typeof(BaseStore<>))
           .As(typeof(IStore<>))
           .InstancePerRequest();
    builder.RegisterAssemblyTypes(Assembly.Load("Project.Data"))
           .Where(t => t.Name.EndsWith("Store"))
           .AsImplementedInterfaces()
           .InstancePerRequest();
            
