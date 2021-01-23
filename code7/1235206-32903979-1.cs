            Container.Register(
            Classes.FromThisAssembly()
                .Pick()
                .Configure(registration => registration.Named(registration.Implementation.Name))
                .WithServiceAllInterfaces()
                .WithServiceSelf()
                .WithServiceBase()
                .LifestyleTransient());
