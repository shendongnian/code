        public Page1() 
        {
          InitializeComponent(); 
          this.Loaded += Page1_Loaded; 
        } 
        void Page1_Loaded(object sender, RoutedEventArgs e) 
        { 
          SystemTray.IsVisible = true; 
          SystemTray.ProgressIndicator = new ProgressIndicator(); 
          SystemTray.ProgressIndicator.Islndeterminate = true; 
          SystemTray.ProgressIndicator.IsVisible = true; 
          Display(); 
          SystemTray.ProgressIndicator.IsVisible = false; 
        }
