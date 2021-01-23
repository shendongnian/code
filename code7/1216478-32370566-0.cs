    public string PlayerName { get; set; }
    public ICommand LoginCommand { get; private set; }
    private void OnLogin(object obj)
    {
        //STORE PlayerName in Global Context and after navigate to MainPage, read it.
        GlobalContext.PlayerName = this.PlayerName;
        this.Frame.Navigate(typeof(MainPage));
    }
    private bool CanLogin(object arg)
    {
        return string.IsNullOrEmpty(PlayerName) ? false : true;
    }
    public CONSTRUCTOR()
    {
        LoginCommand = new DelegateCommand<object>(OnLogin, CanLogin);
    }
