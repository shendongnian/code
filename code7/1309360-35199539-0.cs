    public class NullValidator<TCommand> : IValidator<TCommand> where TCommand : ICommand
    {
        public void Validate(TCommand command)
        {
        }
    }
    public void WithValidatorSucceeds()
    {
        var container = new Container();
        container.Register(typeof(ICommandHandler<>), assemblies);
        container.Register(typeof(IValidator<>), assemblies);
        container.RegisterConditional(
            typeof(IValidator<>), 
            typeof(NullValidator<>), 
            c => !c.Handled);
        container.RegisterDecorator(
            typeof(ICommandHandler<>), 
            typeof(ValidationCommandHandlerDecorator<>));
        container.Verify();
    }
