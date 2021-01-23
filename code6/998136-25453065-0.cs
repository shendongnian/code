        ObjectFactory.Configure(x => x.Scan(s => {
            s.TheCallingAssembly();
            s.AssemblyContainingType<OgreEvents>();
            s.WithDefaultConventions();
            s.Convemtnion<RegisterAllConcreteTypesAgainstAllInterfaces>();
        }));
