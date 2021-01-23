    public MainWindow()
    {
        InitializeComponent();
        var viewModel = new ViewModel();
        DataContext = viewModel;
        Loaded += async (s, e) => await viewModel.DownloadImages();
    }
