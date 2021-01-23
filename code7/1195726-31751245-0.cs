    private static void RegisterObrigatoryServices(IKernel kernel)
            {
                kernel.Bind<IIdentityProvider>().To<ServiceIdentityProvider>();
                kernel.Bind<Guid>().ToMethod(ctx => default(Guid)).Named("CurrentProcessId");
                kernel.Bind<ISession>().ToMethod(ctx =>
                {
                    SessionPoolManager.Update();
    
                    Guid processId = kernel.Get<Guid>("CurrentProcessId", new Parameter[] { });
    
                    if (processId == default(Guid))
                    {
                        return SessionFactoryBuilder.SessionFactory(kernel.Get<IIdentityProvider>()).OpenSession();
                    }
                    else
                    {
                        ISession session = SessionPoolManager.Get(processId);
                        if (session == null)
                        {
                            session = SessionFactoryBuilder.SessionFactory(kernel.Get<IIdentityProvider>()).OpenSession();
                            SessionPoolManager.Register(processId, session);
                        }
    
                        return session;
                    }
                });
            }
