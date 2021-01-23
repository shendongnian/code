    public string Name
    {
        get { return Get(m_name); }
        set { m_name = value; }
    }
    public static T Get<T>(T value)
    {
        if (!loaded)
        {
            loadData();
        } 
        return value;
    }
