        container.Register(Types.FromThisAssembly()
            .BasedOn(typeof(ServiceBase<>))
            .WithService.AllInterfaces()
            .WithService.Select((t, b) => t.BaseType != null
                    ? new[] { t.BaseType }
                    : new Type[0])
            .LifestylePerWebRequest());
