    public interface IPromptableCommandHandler<TCommand>
    {
        void Handle(TCommand command, Action succesAction);
    }
    public class PromptableCommandHandler<TCommand> : IPromptableCommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> commandHandler;
        public PromptableCommandHandler(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }
        public void Handle(TCommand command, Action succesAction)
        {
            try
            {
                this.commandHandler.Handle(command);
                succesAction.Invoke();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured, please try again.");
                // possible other actions like logging
            }
        }
    }
    // use as:
    public void SetGuardActive(Guid guardId)
    {
        this.promptableCommandHandler.Handle(new SetGuardActiveCommand(guardId),() => 
                   this.RefreshGuardsList());
        
    }
