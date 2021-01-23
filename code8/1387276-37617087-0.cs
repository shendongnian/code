    private List<County> _counties;
    public List<County> Counties
    {
        get { return _counties;}
        set
        {
            if (value != _counties)
            {
                _counties = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Counties"));
            }
        }
    }
