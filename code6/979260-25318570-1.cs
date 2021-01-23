    private string _id;
    public string id
    {
        get { return _id; }
        set
        {
            if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("id");
                }
        }
    }
