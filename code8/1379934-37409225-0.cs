    string prop1;
    public string Prop1
    {
        get { return prop1; }
        set
        {
            if (value != prop1)
            {
                prop1 = value;
                OnPropertyChanged("prop1");
            }
        }
    }
