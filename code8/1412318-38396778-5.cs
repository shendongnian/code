    private bool _permissionsFlag;
    public bool PermissionsFlag
    {
        get { return _permissionsFlag; }
        set
        {
            _permissionsFlag = value;
            OnPropertyChanged("PermissionsFlag");
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
