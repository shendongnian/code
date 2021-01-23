    public string someValue = System.Configuration.ConfigurationSettings.AppSettings["key1"];    
    
    public string Property1
    {
        get
        {
            return someValue;
        }
        set
        {
            someValue = value;
        }
    }
