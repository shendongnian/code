    private ICommand testCommand;
    public ICommand TestCommand
    {
        get
        {
            if (testCommand == null)
                testCommand = new RelayCommand(param => TestMeDetails(),
                                               param => CanTestMe());
    
            return testCommand;
        }
    }
    
    public bool CanTestMe()
    {
        return true;
    }
    
    public void TestMeDetails() { }
