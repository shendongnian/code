    public ICommand OnLoadedCommand { get; private set; }
    public MyUserControl()
    {
        OnLoadedCommand = new DelegateCommand(OnLoaded);
    }
    public void OnLoaded()
    {
    }
