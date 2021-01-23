    ICommandProcessor<ICommand> test = new SpecificCommandProcessor(); //not the use of interfaces.
            
    List<ICommandProcessor<ICommand>> myList = new List<ICommandProcessor<ICommand>>(); //again note the use of interfaces
    var toAdd = new SpecificCommandProcessor();
    myList.Add(toAdd);
