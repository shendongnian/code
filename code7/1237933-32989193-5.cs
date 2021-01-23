    public class ApplicationViewModel : IName
    {
        HomeViewModel _homeViewModel;
        SummaryViewModel _summaryViewModel;
        public ApplicationViewModel()
        { 
            //Add pages
            _homeViewModel = new HomeViewModel(this);
            _summaryViewModel = new SummaryViewModel();
            //some code here
            _homeViewModel.SomeProperty = 5;
            CurrentBasePageViewModel = _homeViewModel;
        }
    }
