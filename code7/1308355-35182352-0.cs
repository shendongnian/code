    public class ViewModelLocator
    {
        private NavigationService navigationService;
        private BusinessLogic businessLogic;
        public void InjectNavigationService(NavigationService navigation)
        {
            navigationService = navigation;
        } 
        public void InjectBusinessLogic(BusinessLogic logic)
        {
            businessLogic = logic;
        } 
        public FirstPageViewModel FirstPageViewModel => new FirstPageViewModel(navigationService);
        public SecondPageViewModel SecondPageViewModel => new SecondPageViewModel(navigationService, businessLogic);
    }
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Create/resolve all your objects in Comoposition Root:
            var businessLogic = new BusinessLogic();
            // Here you will have locator created already, but mainWindow has not been created yet
            // Retrive your locator
            ViewModelLocator locator = Resources.Values.OfType<ViewModelLocator>().FirstOrDefault();
            if (locator == null)
                throw new NoNullAllowedException("ViewModelLocator cannot be null.");
            MainWindow mainWindow = new MainWindow();
            var navigation = new NavigationService(mainWindow.MyFrame);
            // Inject your logic and navigation into locator
            locator.InjectBusinessLogic(businessLogic);
            locator.InjectNavigationService(navigation);
            // Set up first page
            navigation.Navigate<FirstPage>();
            // and show the window
            mainWindow.Show();
        }
    }
