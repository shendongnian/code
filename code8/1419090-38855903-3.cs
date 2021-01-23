     Bind<IDetailsService>()
                    .To<DetailsService>()
                    .InRequestScope();
    
                Bind<ISession>()
                    .ToMethod(
                        context =>
                        {
                            var lockObject = new object();
    
                            lock (lockObject)
                            {
                                return context.Kernel.Get<IMasterSessionSource>()
                                    .ExposeConfiguration()
                                    .BuildSessionFactory()
                                    .OpenSession();
                            }
                        }
                    )
                    .WhenInjectedInto<IDetailsService>()
                    .InRequestScope();
