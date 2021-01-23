    private ObservableCollection<Friend> _friends;
    public ObservableCollection<Friend> friends
    {
        get { return _friends; }
        set { _friends = value; 
        RaisePropertyChanged(); }
    }
