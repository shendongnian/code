    private bool _isIdChanged;
    public bool IsIdChanged
    {
    	get { return _isIdChanged; }
    	set { _isIdChanged = value; NotifyPropertyChanged( "IsIdChanged" ); }
    }
