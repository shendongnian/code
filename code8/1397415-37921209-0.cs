    private string _userSelection;
    public string UserSelection
    {
        get
        {
            return _userSelection;
        }
        set
        {
            _userSelection = value;
            UpdateData();
            OnPropertyChanged();
        }
    }
