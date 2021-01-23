    public CommandBindingCollection CommandBindings { get; }
    
    public YourViewModel()
    {
    //Create a command binding for the delete command
    var deleteBinding = new CommandBinding(ApplicationCommands.Delete, DeleteExecuted, DeleteCanExecute);
    
    //Register the binding to the class
    CommandManager.RegisterClassCommandBinding(typeof(YourViewModel), DeleteBinding);
    
    //Adds the binding to the CommandBindingCollection
    CommandBindings.Add(deleteBinding);
    }
