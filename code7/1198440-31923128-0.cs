    public class DefaultCommandValidator<TCommand> : ICommandValidator<TCommand> where TCommand : CommandBase
    {
        public IEnumerable<string> Validate(TCommand command)
        {
            return Enumerable.Empty<string>();
        }
    }
