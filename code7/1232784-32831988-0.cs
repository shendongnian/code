    public class CommandService : ICommandService {
        private readonly Container _container; 
        private readonly ISerializationFormatter _formatter;
        public CommandService(Container container, ISerializationFormatter formatter) {
            _container = container;
            _formatter = formatter;
        }
        public void Execute(string command) {
            if (command == null) throw new ArgumentNullException("command");
            var request = _formatter.Deserialize<CommandRequest>(command);
            Type handlerType = typeof(ICommandHandler<>)
                .MakeGenericType(request.Command.GetType());           
            dynamic handler = _container.GetInstance(handlerType);
            handler.Handle((dynamic)(request.Command));
        }
    }
