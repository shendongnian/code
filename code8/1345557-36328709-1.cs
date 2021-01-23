    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        SourceInitialized += vm.SourceInitialized;
        DataContext = vm;
    }
