    public MainWindow()
    {
        InitializeComponent();
        var viewModel = new ViewModel();
        // fill viewModel.VarConfigList
        DataContext = viewModel;
    }
