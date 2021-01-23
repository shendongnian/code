    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        DataContext = vm;
        vm.TheImage = new BitmapImage(new Uri("dice.png", UriKind.Relative));
    }
