    public MainWindow() 
    {
        InitializeComponent();
    
        Game.DateInfoModel = new DateInfoModel();
        myUserControl.DataContext = new DateInfoViewModel(Game.DateInfoModel);
    }
