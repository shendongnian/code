    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
    }
    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Test");
    }
