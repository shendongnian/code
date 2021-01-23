    private string name;
    public string Name
    {
        get { return name; }
        set 
        {
            test = value;
            FireSomeChangedEvent("Name");
        }
    }
