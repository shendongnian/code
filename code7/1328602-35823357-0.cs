    public MainPage()
    {
        this.InitializeComponent();    
        Startup();        
    }
    private async void Startup()
    {
        await startUpPocedure();   
        setupUI();
    }
