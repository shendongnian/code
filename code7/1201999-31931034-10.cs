    public class MainViewModel 
    {
        public INavigationService NavigationService { get; private set; }
        public MainViewModel(INavigationService navigationService) 
        {
            if(navigationService == null)
                throw new ArgumentNullException(navigationServie);
            NavigationService = navigationService;
        }
    }
