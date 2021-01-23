    public MainWindow()
    {
        InitializeComponent();
        Loaded += InitializeOnLoaded;
    }
    public async void InitializeOnLoaded(object sender, RoutedEventArgs e)
    {
        var vm = new MainViewModel();
        DataContext = vm;
        await vm.InitializeAsync();
    }
