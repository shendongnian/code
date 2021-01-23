    public MainWindow()
    {
        InitializeComponent();
        var vm = new HomeWindowVm();
        SourceInitialized += vm.SourceInitialized;
        DataContext = vm;
    }
