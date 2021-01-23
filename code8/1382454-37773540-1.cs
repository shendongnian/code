    public class MainPage : Page
    {
        MainPageViewModel _viewModel;
        
        public MainPageViewModel ViewModel
        {
          get { return _viewModel??(_viewModel = (MainPageViewModel)this.DataContext); }
        }
    }
