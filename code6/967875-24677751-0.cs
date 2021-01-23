    public class InsertCommandRegistrationConvention : IRegistrationConvention
    {
        private static readonly Type _openHandlerInterfaceType = typeof (ICommandHandler<>);
        private static readonly Type _openInsertCommandHandlerType = typeof (InsertCommandHandler<>);
        private static readonly IList<Type> _customCommandHandlerTypes;
        static InsertCommandRegistrationConvention()
        {
            _customCommandHandlerTypes = _openInsertCommandHandlerType
                .Assembly
                .ExportedTypes
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericType || x.GetGenericTypeDefinition() != typeof (InsertCommandHandler<>))
                .Where(x => x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                .ToArray();
        }
        public void Process(Type type, Registry registry)
        {
            if (!type.IsAbstract && typeof (BaseEntity).IsAssignableFrom(type))
            {
                var insertclosedHandlerInterfaceType = _openHandlerInterfaceType.MakeGenericType(type);
                var closedInsertCommandHandlerType = _openInsertCommandHandlerType.MakeGenericType(type);
                // check for any classes that implement ICommandHandler<T> that are not also InsertCommandHandler<T>
                var customHandler = _customCommandHandlerTypes.FirstOrDefault(t => t.GetInterfaces().Any(i => i == insertclosedHandlerInterfaceType));
                registry.For(insertclosedHandlerInterfaceType)
                    .Use(customHandler ?? closedInsertCommandHandlerType);
            }
        }
    }
