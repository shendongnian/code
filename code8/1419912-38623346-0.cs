    Dictionary<string, string> _dict = new Dictionary<string, string>(
        StringComparer.InvariantCultureIgnoreCase);
    public Dictionary<string, string> dict
    {
    get { return _dict; }
    set { _dict = value; }
    }
