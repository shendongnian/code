    ViewModels.ParameterSettingsVm _viewModel {get;set;}
        public ParameterSettingsUc()
        {
            this.InitializeComponent();
            _viewModel = (ParameterSettingsVm)Resources["viewModel"];
            var bounds = Window.Current.Bounds;
            this.CancelBtn.Width = bounds.Width * .5;
            this.SaveBtn.Width = bounds.Width * .5; 
        }
    
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        { 
            await _viewModel.GetParameters();
            //UserNameBx.Text = _viewModel.DetailData.UserLogin;  //textbox gets filled in.
        }
