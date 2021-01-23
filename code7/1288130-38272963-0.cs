    namespace PrismApplicationTest0.ViewModels
    {
        public class ViewAViewModel : ViewAViewModelBase
        {
            private readonly IRegionManager _regionManager;
            public ViewAViewModel(IEventAggregator eventAggregator,IRegionManager regionManager) : base(eventAggregator)
            {
                _regionManager = regionManager;
            }
            protected override void UpdateMethod()
            {
                // After completing the core functionality
                base.UpdateMethod();
    
                // Switch to another page using platform specific region manager
                _regionManager.RequestNavigate(RegionNames.ContentRegion,"ViewB");
            }
          }
    }
