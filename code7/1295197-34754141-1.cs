    public class TransactionScopeCommandHandlerDecorator<TCommand> 
            : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> decoratee;
        public TransactionScopeCommandHandlerDecorator(ICommandHandler<TCommand> decoratee)
        {
            this.decoratee = decoratee;
        }
        public void Handle(TCommand command)
        {
            using (var scope = new TransactionScope())
            {
                this.decoratee.Handle(command);
                scope.Complete();
            }
        }
    }
