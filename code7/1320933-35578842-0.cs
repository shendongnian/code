    private Host host;
    public WindowsDxService()
    {
        InitializeComponent();
    }
    protected override void OnStart(string[] args)
    {
        this.host = new NancyHost(...)
        this.host.Start();
    }
    protected override void OnStop()
    {
        this.host.Stop();
        this.host.Dispose();
    }
