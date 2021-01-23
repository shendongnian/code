    public MainWindow()
    {
        InitializeComponent();
    
        MainViewModel vm = new MainViewModel();
        this.DataContext = vm;
    }
