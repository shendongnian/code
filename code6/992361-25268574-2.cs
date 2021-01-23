    public Database DatabaseInfo
    {
        get { return _DatabaseInfo; }
        set
        {
            if (_DatabaseInfo != value)
            {
                _DatabaseInfo = value;
                NotifyPropertyChanged(m => m.DatabaseInfo);
                DatabaseInfo.PropertyChanged += DataBasePropertyChanged;
            }
        }
    }
    
...
    private void DataBasePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        NotifyPropertyChanged(m => m.DatabaseInfo);
    }
