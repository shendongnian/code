    public class Model
    {
       public string Name {get;set;}
       public int Age {get;set;}
       public void UpdateModel() {...}
    }
    
     public interface ICommandFactory
    {
        string CommandName { get; }
        string Description { get; }
    
        ICommand MakeCommand(Action<Model>);
        ICommand MakeCommandFunc(Func<Model, bool>);
    }
    public class Command : ICommand
    {
        Action<Model> _action;
        Command(Action<Model> action)
        {
           _action = action;
        }
     
        Execute()
        {
            _action();
        }
    }
