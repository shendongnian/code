    HomeViewModel _homeViewModel;
    SummaryViewModel _summaryViewModel;
    public ApplicationViewModel()
    {
        //Add pages
        _homeViewModel = new HomeViewModel();
        _summaryViewModel = new SummaryViewModel();
   
        //some code here
        _homeViewModel.SomeProperty = 5;
        CurrentBasePageViewModel = _homeViewModel;
    }
