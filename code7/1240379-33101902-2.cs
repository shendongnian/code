    public ViewModelLocator()
    {
        ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
    
        var navigationService = this.CreateNavigationService();
        
        SimpleIoc.Default.Register<INavigationService>(() => navigationService);
     
        SimpleIoc.Default.Register<IDialogService, DialogService>();
     
        SimpleIoc.Default.Register<MainViewModel>();
        SimpleIoc.Default.Register<DetailsViewModel>();
    }
    private INavigationService CreateNavigationService()
    {
      var navigationService = new NavigationService();
      navigationService.Configure("Details", typeof(DetailsPage));
      // navigationService.Configure("key1", typeof(OtherPage1));
    //From a working project.
    navigationService.Configure("tnc", new System.Uri("/Views/TncAgreement.xaml", System.UriKind.Relative));
      
 
     return navigationService;
    }
