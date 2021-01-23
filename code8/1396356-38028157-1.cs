    abstract class BaseCommand : ICommand
    {
         // it could be put anywhere else as long as it can be accessed in command's Execute
         // it can also be a stack
         public static CommandContext Context {get; set;} 
    }
    class MutliCommand : BaseCommand 
    {
        public void Execute()
        {
            // do something to BaseCommand.Context
            
            ChildCommand.Execute();
            
            // do something to BaseCommand.Context
        }
    }
    class ChildComand: BaseCommand 
    {
         void Execute() 
         {
              // do something with BaseCommand.Context
         }
    }
