    public class ViewModelLocator {
        static ViewModelLocator() {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CatalogViewModel>();
            SimpleIoc.Default.Register<DownloadsViewModel>();
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //Done so an instance will be generated and held in cache
            var dl = ServiceLocator.Current.GetInstance<DownloadsViewModel>()
        }
    
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
    
        public CatalogViewModel Catalog
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CatalogViewModel>();
            }
        }  
    
        public DownloadsViewModel Downloads
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DownloadsViewModel>();
            }
        }
    }
