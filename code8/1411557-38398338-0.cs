            // Register the dll's, except the singleton ones.
            builder.RegisterAssemblyTypes(assembliesToRegister)
                    .AsImplementedInterfaces()
                    .Except<IOne>()
                    .Except<ITwo>();
