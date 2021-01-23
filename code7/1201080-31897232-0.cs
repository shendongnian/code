    public ICommand btnStartCommand {get; set;}
    public MainViewModel()
    {
        btnStartCommand = new Command(StartCommand);
    }
    public void StartCommand()
    {
        //here you create your call to the startTimer() method
    }
