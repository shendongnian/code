    public MainPage()
    {
        this.InitializeComponent();
        ViewModel = new MainPageViewModel();
    }
    
    public MainPageViewModel ViewModel { get; set; }
