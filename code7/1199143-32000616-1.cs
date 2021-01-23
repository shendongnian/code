    public NavigationContextControlViewModel(IRegionManager regionManager)
    {
        IRegionNavigationService navigationService;
        this.RegionManager = regionManager;
        navigationService = this.RegionManager.Regions[UIRegionNames.ContextResultsPane].NavigationService;
        navigationService.Navigated += CheckIfNavigateCanExecuteHasChanged;
        this.ContextResultsNavigationJournal = navigationService.Journal;
    }
