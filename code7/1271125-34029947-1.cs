    [ServiceKnownType(nameof(GetKnownTypes)]
    public class CommandService
    {
        [OperationContract, FaultContract(typeof(ValidationError))]
        public void Execute(dynamic command) {
            CreateCommandHandler(command.GetType()).Handle(command);
        }
     
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider cap) {
            yield return typeof(ShipOrder);
            yield return typeof(CancelOrder);
            yield return typeof(ConfirmOrder);
        }
        
        // Singletons
        private static IUserContext userContext = new WcfUserContext();
        
        private static dynamic CreateCommandHandler(Type commandType)
        {
            var context = new DbContext();
        
            if (commandType == typeof(ShipOrder))
                return Decorate(new ShipOrderHandler(context));
            if (commandType == typeof(CancelOrder))
                return Decorate(new CancelOrderHandler(context));
            if (commandType == typeof(ConfirmOrder))
                return Decorate(new ConfirmOrderHandler(context, userContext));
            throw new ArgumentException("Unknown: " + commandType.FullName);
        }
        
        private static ICommandHandler<T> Decorate<T>(ICommandHandler<T> handler) {
            return new WcfExceptionTranslatorCommandHandlerDecorator(
                new LoggingCommandHandlerDecorator(
                    new Logger(),
                    new AuditTrailingCommandHandlerDecorator(
                        new PermissionCheckerCommandHandlerDecorator(
                            new ValidationCommandHandlerDecorator(
                                new TransactionCommandHandlerDecorator(
                                    handler))))));
        }
    }
