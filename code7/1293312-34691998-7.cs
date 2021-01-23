    private string _Query;
    public string Query
    {
        get { return _Query; }
        set
        {
            _Query = value;
            //Notify property changed.
            OnPropertyChanged("FilteredCollection1");
        }
    }
