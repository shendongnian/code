    public MainWindow()
    {
        ConnectFourViewModel ViewModel = new ConnectFourViewModel();
        . . .
        . . .
        DataContext = ViewModel ;
        InitializeComponent();
    }
