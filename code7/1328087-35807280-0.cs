    public MainPage : Page
    {
        protected  MainPage()
        {
            view = new View();
            _initTask = Init()
        }
    
        private async Task Init()
        {
            FacebookApiHandler FacebookApiHandler = new FacebookApiHandler(view);
            await FacebookApiHandler.getAccessByLogin();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            this.InitializeComponent();
        }
        private Task _initTask.
    
        public static Task<MainPage> CreatePageAsync()
        {
             var page = new MainPage();
             await page._initTask;
             return page;
        }
    }
    //Elsewhere
    private async Task MyCode()
    {
         MainPage page = await MainPage.CreatePageAsync();
    }
