    private string value1;
    
    public string Value1
    {
        get { return value1; }
        set
        {
            value1 = value;
            this.NotifyPropertyChange("Value1");
        }
    }
