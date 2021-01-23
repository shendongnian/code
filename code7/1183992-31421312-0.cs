      public class MainViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private RelayCommand _navigateCommand;
        public RelayCommand NavigateCommand
        {
            get
            {
                return _navigateCommand
                    ?? (_navigateCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("PreRegisterPage");
                    }));
            }
        }
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;           
        }
    }
