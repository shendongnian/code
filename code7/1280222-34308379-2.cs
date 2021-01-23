    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<BaseViewModel>();
            SimpleIoc.Default.Register<NavigationViewModel>();
        }
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public BaseViewModel BaseViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BaseViewModel>();
            }
        }
        public NavigationViewModel NavigationViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NavigationViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
