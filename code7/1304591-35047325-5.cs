    public MainWindow()
    {
        var viewModel = new SheepViewModel();
        ScoreScreen SW = new ScoreScreen();
        SW.DataContext = viewModel;
        SW.Show();
        InitializeComponent();
        //NOTICE!  After Init is called!
        DataContext = viewModel;
    }
