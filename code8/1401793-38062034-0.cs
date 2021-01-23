    public AllMidContext() :    base(ConfigAccess.GetDefaultConnectionString())
    {}
    [Inject]
    public IConfigurationAccess ConfigAccess
    {
        get;
        set;
    }
