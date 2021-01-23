    private static InitialStartDone = false; // declared in service class
    protected Overrride void OnStart(string[] args);
    {
        if(!InitialStartDone)
        {
            InitialStartDone = true;
        }
        else
        {
            base.OnStart(args);
        }
    }
