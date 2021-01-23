    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        DataContext = vm;
        vm.LoadImagePaths(@"C:\Users\Public\Pictures\Sample Pictures");
    }
