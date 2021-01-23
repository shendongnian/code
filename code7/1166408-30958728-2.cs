    using StructureMap;
    using StructureMap.Configuration.DSL;
    
    public class CommandHandlerRegistry : Registry
    {
        public CommandHandlerRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType(typeof(ICommandHandler<>));
                scanner.Exclude(t => t == typeof(Decorator1<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
            });
            For(typeof(ICommandHandler<>)).DecorateAllWith(typeof(Decorator1<>));
        }
    }
