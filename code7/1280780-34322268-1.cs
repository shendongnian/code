    private readonly DelegateCommand _executeCommand;
    public DelegateCommand ExecuteCommand { /* get only */ }
    public Presenter()
    {
        _excuteCommand = new DelegateCommand
        (
            () => /* execute code here */,
            () => FilePath != null /* this is can-execute */
        );
    }
    public string FilePath
    {
        get { return filePath; }
        set 
        { 
            filePath = value;
            RaisePropertyChangedEvent("FilePath");
            ExecuteCommand.OnCanExecuteChanged(); // So the bound control updates
        }
    }
