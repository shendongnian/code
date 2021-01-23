    ICommand startTestCommand;
    public ICommand StartTestCommand { get { return startTestCommand ?? (startTestCommand = new RelayCommand(StartTest)); }
    private void StartTest()
    {
        //This will execute if the Command is bound in XAML
    }
