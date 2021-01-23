    public ObservableConcurrentDictionary<string, string> _hostList = new ObservableConcurrentDictionary<string, string>();
    public MainWindow()
    {
        InitializeComponent();
        _hostList.Add("TestHost1", "Host1");
        _hostList.Add("TestHost2", "Host2");
        _hostList.Add("TestHost3", "Host3");
        DataContext = _hostList;
    } 
