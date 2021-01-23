    public class InsertCommandRegistrationConvention : IRegistrationConvention
    {
        private static readonly Type _openHandlerInterfaceType = 
            typeof(ICommandHandler<>);
        private static readonly Type _openInsertCommandHandlerType = 
            typeof(InsertCommandHandler<>);
        public void Process(Type type, Registry registry)
        {
            if (!type.IsAbstract && typeof(BaseEntity).IsAssignableFrom(type))
            {
                Type closedInsertCommandHandlerType =
                    _openInsertCommandHandlerType.MakeGenericType(type);
                Type insertclosedHandlerInterfaceType =
                    _openHandlerInterfaceType.MakeGenericType(type);
                registry.For(insertclosedHandlerInterfaceType)
                    .Use(closedInsertCommandHandlerType);
            }
        }
    }
