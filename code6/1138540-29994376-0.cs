     public class CustomServiceHostFactory : ServiceHostFactory
        {
            protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
            {
                var container = InitializeDIContainer();
        
                // Add this line and try again.
                AutofacServiceHost.Container = container;
        
                var customHost = new CustomServiceHost(serviceType, baseAddresses);
                
                customHost.AddDependencyInjectionBehavior(serviceType, container);
                return customHost;
            }
        
            private static IContainer InitializeDIContainer()
            {
                var builder = new ContainerBuilder();
                builder.RegisterAssemblyTypes(typeof (AccountRepository).Assembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .As(t => t.GetInterfaces().FirstOrDefault(
                        i => i.Name == "I" + t.Name));
        
                builder.RegisterAssemblyTypes(typeof (AccountService).Assembly)
                    .Where(t => t.Name.EndsWith("Service"))
                    .As(t => t.GetInterfaces().FirstOrDefault(
                        i => i.Name == "I" + t.Name));
        
                builder.RegisterType<tktktktkDbContext>().As<IDataContextAsync>();
                builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>();
        
                var container = builder.Build();
                return container;
            }
        }
