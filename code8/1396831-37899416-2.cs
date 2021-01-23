    public class ViewModelLocator {
        static ViewModelLocator() {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CatalogViewModel>();
            SimpleIoc.Default.Register<CreatorViewModel>();
            SimpleIoc.Default.Register<DownloadsViewModel>();
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //Default instance
            //Done so an instance will be generated and held in cache
            var defaultDownloadsViewModel = ServiceLocator.Current.GetInstance<DownloadsViewModel>();
        }
        public ViewModelLocator(){
            Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
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
    
        private void NotifyUserMethod(NotificationMessage message )
        {
            MessageBox.Show(message.Notification);
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        
        }
    }
