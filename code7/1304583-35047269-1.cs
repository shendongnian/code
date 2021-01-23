    public MainWindow()
    {
        InitializeComponent();
        SheepViewModel svm = new SheepViewModel();
        this.DataContext = svm;
        ScoreScreen SW = new ScoreScreen();
        SW.DataContext = svm;
        SW.Show();        
    }
