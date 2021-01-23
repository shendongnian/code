    private Dictionary<string,Something>;
    public Something this[string i]
    {
        get { return InnerDictionary[i]; }
        set { InnerDictionary[i] = value; }
    }
