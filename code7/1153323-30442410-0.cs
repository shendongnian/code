    public interface ICommandBus
    {
        TResult Publish<TResult>(ICommand<TResult> command)
            where TResult : ICommandResult;
    }
