    public MainWindow()
    {
        InitializeComponent();
        DataContext = Directory.EnumerateDirectories(@"I:\");
    }
