    public class CommandDispatcher : ICommandDispatcher
    {
        ICommandHandlerFactory _commandHandlerFactory;
        public CommandDispatcher(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }
        public ICommandResult Submit<TCommand>(TCommand command) where TCommand : Commands.ICommand
        {
            try
            {
                var handler = _commandHandlerFactory.Resolve<TCommand>();
                return handler.Execute(command);
            }
            catch (ComponentNotFoundException cnfex)
            {
                // log here
                throw cnfex;
            }
            
        }
    }
