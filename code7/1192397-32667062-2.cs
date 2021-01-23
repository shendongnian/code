    public BrowserViewModel ViewModel { get; set; }
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = new BrowserViewModel();//creating new instance
            DataContext = ViewModel;//setting view model as data context - later used in binding
        }
