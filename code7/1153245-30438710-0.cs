    public string value1
    {
        get { return value1; }
        set
        {
            value1 = value;
            this.NotifyPropertyChange("value1");
        }
    }
