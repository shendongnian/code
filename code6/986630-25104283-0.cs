    private RelayCommand printCommand;
    public RelayCommand PrintCommand
    {
        get { return printCommand?? (printCommand = new RelayCommand(param => ExecutePrintCommand())); }
    }
    private void ExecutePrintCommand()
    {
        // your code here
    }
