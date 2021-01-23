    public sealed class CommandService : ICommandService {
        private readonly Container _container; 
        private readonly ISerializationFormatter _formatter;
        public CommandService(Container container, ISerializationFormatter formatter) {
            _container = container;
            _formatter = formatter;
        }
        public void Execute(string command) {
            if (command == null) throw new ArgumentNullException("command");
            var request = _formatter.Deserialize<CommandRequest>(command);
            Type handlerType = typeof(WeaklyTypedCommandHandler<>)
                .MakeGenericType(request.Command.GetType());           
            var handler = (ICommandHandler)_container.GetInstance(handlerType);
            handler.Handle(request.Command);
        }
        
        private interface ICommandHandler {
            void Handle(object command);
        }
        public class WeaklyTypedCommandHandler<TCommand> : ICommandHandler {
            private readonly ICommandHandler<TCommand> _commandHandler;
            public WeaklyTypedCommandHandler(ICommandHandler<TCommand> commandHandler) {
                _commandHandler = commandHandler;
            }
            public void Handle(object command) {
                _commandHandler.Handle((TCommand)command);
            }
        }
    }
