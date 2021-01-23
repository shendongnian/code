    public class UserAccountsStatusHandler : INotifyPropertyChanged
    {
        //Event Aggregator from Prism PubSub
        private readonly IEventAggregator eventService = (System.Windows.Application.Current as App).EventService;
    
        private bool isSavedEnabled;
        public bool IsSaveEnabled 
        { 
            get 
            { 
                return isSavedEnabled; 
            } 
    
            set 
            { 
                isSavedEnabled = value; 
                OnPropertyChanged("IsSaveEnabled"); 
                // Publish to all subscribers
                this.eventService.GetEvent<SaveEnabledEvent>().Publish(this);
            } 
        }
    }
