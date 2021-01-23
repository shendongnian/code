    public AppMainPage ()
            {
                InitializeComponent ();
    
                MainViewModel mainViewModel = new MainViewModel();
                BindingContext = mainViewModel;
            }
