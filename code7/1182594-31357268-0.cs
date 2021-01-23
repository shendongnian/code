    private string _username;
    public string Username
    {
        get { return _username; }
        set
        {
            _username = value;
            RaisePropertyChanged("Username"); // notification
        }
    }
