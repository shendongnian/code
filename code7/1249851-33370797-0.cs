    // define a command property
    public ICommand DeleteCommand { get; set; }
    
    // in your constructor, initialize the command
    DeleteCommand = new Command<string>((id) =>
    {
      // do the appropriate delete action here
    }
