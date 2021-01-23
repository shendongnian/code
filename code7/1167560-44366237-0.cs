    internal bool IDSpecified = false;
    private int id;
    public int ID
    {
        get { return id; }
        set
        {
            id = value;
            IDSpecified = true;
        }
    }
