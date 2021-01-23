    namespace MvvmLight1.ViewModel
    {
        public class ViewModelLocator
        {
            public ViewModelLocator()
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                SimpleIoc.Default.Register<MainViewModel>();
            }
            public MainViewModel Main
            {
                get
                {
                    return ServiceLocator.Current.GetInstance<MainViewModel>();
                }
            }
        }
    }
