    public class CommandingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>()
                .Register(
                    Classes.FromThisAssembly()
                        .BasedOn(typeof (ICommandHandler<>))
                        .WithServiceAllInterfaces()
                        .LifestyleTransient(),
                    Component.For<ICommandHandlerFactory>().AsFactory(),
                    Component.For<ICommandDispatcher>().ImplementedBy(typeof (CommandDispatcher)));
        }
    }
