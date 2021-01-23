    public ObservableCollectionEx<SItem> SItemCollection 
    {
        get
        {
            return _sitemCollection;
        }
        set
        {
            if (_sitemCollection!= value)
            {
                _sitemCollection= value;
                RaisePropertyChanged("SItemCollection");
            }
        }
    }
    ObservableCollectionEx<SItem> _sitemCollection;
