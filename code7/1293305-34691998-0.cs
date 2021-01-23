    private string _Query;
    public string Query
    {
        get { return _Query; }
        set
        {
            _Query = value;
            Filter();
            //Notify property changed.
        }
    }
