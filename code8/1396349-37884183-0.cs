    public class CommandContext
    {
        // The object that will be the target of the commands' actions.
        public object Data { get; set; }
    
        // ... any other properties that might be useful as shared state between commands...
    }
    
    public abstract class BaseCommand : ICommand
    {
        protected CommandContext Context { get; private set; }
        
        public BaseCommand(CommandContext ctx)
        {
            Context = ctx;
        }
    }
    
    public class ChangeSomethingIDCommand : BaseCommand
    {
        public ChangeSomethingIDCommand(CommandContext ctx) : base(ctx)
        { }
    
        public void Execute()
        {
            var target = (SomeDomainClass)Context.Data;
            target.SomethingID++;
        }
    }
    
    // Elsewhere in your code (assuming 'myTargetDomainClassInstance' is
    // a SomeDomainClass instance that has been instantiated elsewhere and
    // represents the object upon which the commands will do work):
    var ctx = new CommandContext { Data = myTargetDomainClassInstance };
    var commandGroup = new MultiItemCommand(ctx, new List<ICommand>
        {
            new ChangeSomethingIDCommand(ctx),
            new Command2(ctx),
            new Command3(ctx)
        });
    
    commandGroup.Execute();
