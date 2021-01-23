    public override ObjectContext ObjectContext
    {
        get
        {
            Initialize();
            return ObjectContextInUse;
        }
    }
    public void Initialize()
    {
        InitializeContext();
        InitializeDatabase();
    }
