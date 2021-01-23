    public ViewModel MyViewModel { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        MyViewModel = new ViewModel();
        DataContext = MyViewModel;
    }
