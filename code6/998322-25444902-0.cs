    private ICommand createPersonCommand;
    public ICommand CreatePersonCommand
    {
        get {
            if (createPersonCommand == null) {
                createPersonCommand = new DelegateCommand<object>(ExecuteCreatePersonCommand)
            }
            return createPersonCommand;
        }
    }
    
