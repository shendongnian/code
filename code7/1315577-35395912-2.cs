    public string FirstName
    {
        get { return _Student.FirstName; }
        set
        {
            _Student.FirstName = value;
            NotifyPropertyChanged("FirstName");
            NotifyPropertyChanged("FullName");
        }
    }
    public string LastName
    {
        get { return _Student.LastName; }
        set
        {
            _Student.LastName = value;
            NotifyPropertyChanged("LastName");
            NotifyPropertyChanged("FullName");
        }
    }
