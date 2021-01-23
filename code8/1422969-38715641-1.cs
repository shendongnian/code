    public MainWindow()
    {
        var ports = new List<string>(System.IO.Ports.SerialPort.GetPortNames());
        var cb = new ObservableCollection<MyPortModel>();
        foreach (var x in ports)
        {
            var p = new System.IO.Ports.SerialPort(x);
            cb.Add(new MyPortModel { DisplayName = x,IsOpen = p.IsOpen});
        }
        PortsList = cb;
        this.DataContext = this;
        InitializeComponent();
    }
    public ObservableCollection<MyPortModel> PortsList { get; set; }
