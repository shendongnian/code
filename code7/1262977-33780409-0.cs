    public interface ICommandProcessor<out T> where T : ICommand
    {
    }
    ICommandProcessor<ICommand> test = new SpecificCommandProcessor(); //will compile.
            
    List<ICommandProcessor<ICommand>> myList = new List<ICommandProcessor<ICommand>>();
    var toAdd = new SpecificCommandProcessor();
    myList.Add(toAdd); //will compile
