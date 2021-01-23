    public MyViewModel()
    {
        MyCommand = new RelayCommand(OnExecute, CanExecute);
    }
    
    public ICommand MyCommand { get; }
