    public MainWindow()
    {
        InitializeComponent();
        ScoreScreen SW = new ScoreScreen();
        SW.DataContext = this.DataContext;
        SW.Show();        
    }
