    public interface IHandleQuery<TQuery, TResult> where TQuery : IQuery<TResult> 
    {
        TResult Handle(TQuery query);
    }
    public interface IHandleCommand<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
