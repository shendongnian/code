            container.AddFacility<TypedFactoryFacility>();
            container.Register(Component.For<Service>().LifestyleTransient());
            container.Register(Component.For<IRepository>().ImplementedBy<Repository>().LifestyleScoped());
            container.Register(Component.For<ICommand>().ImplementedBy<Command>().LifestyleTransient());
            container.Register(Component.For<ICommandFactory>().AsFactory().LifestyleTransient());
            
            using (container.BeginScope())
            {
                var service = container.Resolve<Service>();
                service.DoIt();
            }
