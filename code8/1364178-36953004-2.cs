        public MainWindowViewModel
        { 
            var regionData = new HaveLoginData();
            this.AddViewModel(new LoginViewModel() { DisplayName = "Login", InternalName = "LoginViewModel", RegionData = regionData }); 
            this.AddViewModel(new GeneralViewModel() { DisplayName = "General", InternalName = "GeneralViewModel", RegionData = regionData }); 
            this.Current_ViewModel = this.GetViewModel("LoginViewModel");
        }
