    [ServiceKnownType(nameof(GetKnownTypes)]
    public class CommandService
    {
        [OperationContract]
        [FaultContract(typeof(ValidationError))]
        public void Execute(dynamic command) {
            CreateCommandHandler(command.GetType()).Handle((dynamic)command);
        }
     
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider p) {
            yield return typeof(ShipOrder);
            yield return typeof(CancelOrder);
            yield return typeof(ConfirmOrder);
        }
        
        // Singletons
        private static ITimeProvider timeProvider = new RealTimeProvider();
        private static IUserContext userContext = new WcfUserContext();
        
        private static dynamic CreateCommandHandler(Type commandType)
        {
            var context = new DbContext();
        
            if (commandType == typeof(ShipOrder))
                return Decorate(new ShipOrderHandler(context));
            if (commandType == typeof(CancelOrder))
                return Decorate(new CancelOrderHandler(context, timeProvider));
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
                                new DeadlockRetryCommandHandlerDecorator(
                                    new TransactionCommandHandlerDecorator(
                                        handler)))))));
        }
    }
