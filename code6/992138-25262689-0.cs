    public DateTime SomeProperty
    {
        get { return someProperty; }
        set
        {
            someProperty = value;
            NotifyPropertyChanged("SomeProperty");
        }
    }
