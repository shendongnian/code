    public MainWindow()
    {
        Debug.WriteLine("Initializing");
        InitializeComponent();
        Debug.WriteLine("Initialized");
        Debug.WriteLine("Setting DataContext");
        DataContext = new ViewModel();
        Debug.WriteLine("DataContext Set");
    }
