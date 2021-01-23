    public sealed partial class MainPage : Page
    {
        MainPageViewModel _viewModel;
        public MainPageViewModel ViewModel
        {
            get { return _viewModel ?? (_viewModel = (MainPageViewModel)DataContext); }
        }    
    }
