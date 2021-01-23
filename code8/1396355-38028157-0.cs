    abstract class BaseCommand<T> : ICommand
    {
        public T Context { get; set; }
        public BaseCommand Parent { get; set; }
    }
    class MultiCommand : BaseCommand 
    {
         public void AddChildCommand(BaseCommand command) 
         {
             command.parent = this; // we can get parent's context from children now
             // put the command in an internal list
         }
    }
    var commandsGroup = new MultiCommand();
    commandsGroup.AddChildCommand(new Command1());
    commandsGroup.AddChildCommand(new Command2());
    commandsGroup.AddChildCommand(new Command3());
    commandsGroup.Execute()
