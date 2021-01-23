    private Timer _timer;
    private DateTime _lastRun = DateTime.Now.AddDays(-1);
    public SpotlessService()
    {
        InitializeComponent();
    }
    protected override void OnStart(string[] args)
    {
        _timer = new Timer(1 * 60 * 1000); // every 1 minute
        _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        _timer.Start();
    }
    public void Start()
    {
        OnStart(new string[0]);
    }
    void timer_Elapsed(object sender, EventArgs e)
    {
        _timer.Stop();
 
        Util.LogError("Started at" + DateTime.Now + "");
        FileDownload objdwn = new FileDownload();
        _timer.Start()
    }
  
    
