    bool _isAuthenticateButtonEnabled;
    public bool IsAuthenticateButtonEnabled 
    {
        get { return _isAuthenticateButtonEnabled; }
        set
        {
            _isAuthenticateButtonEnabled = value;
            OnPropertyChanged();
            AuthenticateCommand.Update();
        }
    }
    // the base could class could actually implement this
    void OnPropertyChanged([CallerMemberName] string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    public DelegateCommand AuthenticateCommand { get; }
    // view model constructor
    public ViewModel()
    {
        AuthenticateCommand = new DelegateCommand(o =>
        {
           ... // some actions when command is executed
        }, o =>
        {
           bool somecondition = ...; // some condition to disable button, e.q. when executing command
           return somecondition && IsAuthenticateButtonEnabled;
        });
    }
