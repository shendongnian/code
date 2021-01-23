            Container.Register(
            Classes.FromThisAssembly()
                .Pick()
                .WithServiceAllInterfaces()
                .WithServiceSelf()
                .WithServiceBase()
                .LifestyleTransient());
