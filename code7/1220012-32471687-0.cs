    public MainViewModel()
    {
        InitCommand = new RelayCommand(Init);
    }
    public ICommand InitCommand { get; private set; }
    private void Init()
    {
        throw NotImplementedException();
    }
