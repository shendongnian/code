     Bind<IContentService>().To<ContentService>().InRequestScope();
            Bind<ISession>()
                .ToMethod(
                    context =>
                        context.Kernel.Get<IMasterSessionSource>()
                            .ExposeConfiguration()
                            .BuildSessionFactory()
                            .OpenSession()
                )
                .WhenInjectedInto<IContentService>()
                .InRequestScope(); 
