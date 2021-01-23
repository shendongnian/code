    private RelayCommand _backCommand;
    public ICommand BackCommand
    {
        get { return _backCommand ?? (_backCommand = new RelayCommand(Back)); }
    }
