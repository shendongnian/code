        public MainWindowViewModel
        { 
            var regionData = new HaveLoginData();
            this.AddViewModel(new LoginViewModel() { RegionData = regionData }); 
            this.AddViewModel(new GeneralViewModel() { RegionData = regionData }); 
            this.Current_ViewModel = this.GetViewModel("LoginViewModel");
        }
