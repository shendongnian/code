    public class MainViewModel : ViewModelBase
    {
            protected readonly IEventAggregator _eventAggregator;
    
            public MainViewModel(IEventAggregator eventAggregator)
            {
                PageViewModels.Add(new FirstViewModel());
                PageViewModels.Add(new SecondViewModel(ApplicationService.Instance.EventAggregator)));
    
                PageViewModels.Add(new ThirdViewModel());
    
                // Set starting page
                CurrentUserControl = PageViewModels[0];
    
                this._eventAggregator = eventAggregator;
            }
    
            private void GoToThird()
            {
                CurrentUserControl = PageViewModels[0];
            } 
    }
