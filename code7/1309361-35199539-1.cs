    public class NullValidator<TCommand> : IValidator<TCommand> where TCommand : ICommand
    {
        public void Validate(TCommand command)
        {
        }
    }
