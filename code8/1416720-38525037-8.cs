    public MainWindow()
    {
        Debug.WriteLine("Setting DataContext");
        DataContext = new ViewModel();
        Debug.WriteLine("DataContext Set");
        Debug.WriteLine("Initializing");
        InitializeComponent();
        Debug.WriteLine("Initialized");
    }
