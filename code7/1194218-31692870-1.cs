    private Lazy<List<string>> l;
    public Der1
    {
        l = new Lazy<List<string>>(() => Run());
    }
    public List<string> ResultOfRun
    {
        get
        {
             return l.Value();
        }
    }
