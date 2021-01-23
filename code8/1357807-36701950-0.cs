    public MainWindow() 
    {
        InitializeComponent();
    
        Game.DateInfoModel = new DateInfoModel();
        this.DataContext = new DateInfoViewModel(Game.DateInfoModel);
    }
