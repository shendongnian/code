        static void Main(string[] args)
        {
            var container = new Castle.Windsor.WindsorContainer();
            container.Register(
                    Component.For<IHigherBusiness>()
                    .ImplementedBy<HigherBusiness>()
                    .DependsOn(Dependency.OnComponent(typeof(ISomeBusiness),
                                "BusinessWithExtendedLogger"))
                );
            container.Register(Component.For<ISomeBusiness>().ImplementedBy<Business>()
                    .DependsOn(Dependency.OnComponent<ILogger, FullDetailLogger>())
                    .Named("BusinessWithExtendedLogger")
                );
            container.Register(Component.For<ISomeBusiness>().ImplementedBy<Business>()
                    .DependsOn(Dependency.OnComponent<ILogger, SimpleLogger>())
                    .IsDefault()
                );
            container.Register(Component.For<ILogger>().ImplementedBy<FullDetailLogger>()
                    .IsFallback()
                );
            container.Register(Component.For<ILogger>().ImplementedBy<SimpleLogger>());
            var business = container.Resolve<IHigherBusiness>();
            business.DoSomething();
            var normalBusiness = container.Resolve<ISomeBusiness>();
            normalBusiness.DoSomething();
            var logger = container.Resolve<ILogger>();
            logger.Log("Some Log... .");
            Console.ReadKey();
        }
