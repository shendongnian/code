    private String _username = null;
    public String username { 
        get { return _username; } 
        set {
            if (value != _username)
            {
                _username = value;
                OnPropertyChanged();
            }
        } 
    }
