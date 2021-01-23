    public MainWindow()
    {
        InitializeComponent();
        ViewModel = SheepViewModel.GetDetails(); // include this line
        ScoreScreen SW = new ScoreScreen();
        SW.Show();
    }
