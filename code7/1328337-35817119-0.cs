    Runspace rs;
    public MainWindow()
    {
        InitializeComponent();
        rs = RunspaceFactory.CreateRunspace();
        rs.Open();
    }
