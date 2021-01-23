            container.Register(
                Component.
                    For<IErrorCodes>().
                    ImplementedBy<DefaultErrorCodes>().
                    IsFallback(),
                Classes.
                    FromAssemblyInDirectory(new AssemblyFilter("bin")).
                    BasedOn<IErrorCodes>().
                    Unless(t => t.IsAbstract).
                    WithServiceBase().
                    LifestyleSingleton());
