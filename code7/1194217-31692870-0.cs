    private Lazy<string> l;
    public Der1
    {
        l = new Lazy<string>(() => Run());
    }
     public List<string> ResultOfRun
     {
        get
        {
             return l.Value();
        }
    }
