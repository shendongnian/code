    private object obj = new object();
    private string _active;
    private string acctive
    {
        get {
            lock (obj)
            {
                return _active;
            }
        }
        set
        {
            lock (obj)
            {
                _active = value;
            }
        }
    }
