        interface IVerificationHandler
        {
        }
         class RemoteVerificationHandler : IVerificationHandler
        {
        }
         class InMemoryVerificationHandler : IVerificationHandler
        {
        }
         enum Source
        {
            Remote,
            InMemory
        }
         void AutoRegistrationUsage()
        {
            var container = new Container();
             //Register keyed factory by specifying key (Source) and value (IVerificationHandler)
            container.RegisterInstance<IKeyedFactory<Source, IVerificationHandler>>(new KeyedFactory<Source, IVerificationHandler>(container, Lifestyle.Transient)
            {
                { Source.InMemory, typeof(InMemoryVerificationHandler) },
                { Source.Remote, typeof(RemoteVerificationHandler) }
            });
        }
         void ManualRegistrationUsage()
        {
            var container = new Container();
             //Register keyed factory by specifying key (Source) and value (IVerificationHandler)
            container.RegisterInstance<IKeyedFactory<Source, IVerificationHandler>>(new KeyedFactory<Source, IVerificationHandler>(container, Lifestyle.Transient)
            {
                { Source.InMemory, typeof(InMemoryVerificationHandler) },
                { Source.Remote, typeof(RemoteVerificationHandler) }
            });
        }
