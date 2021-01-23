    public MainWindow()
    {
        InitializeComponent();
        Task.Factory.StartNew(PopList);
    }
