    public class UserAccountsStatusHandler : INotifyPropertyChanged
    {
        //Event Aggregator from Prism PubSub
        private readonly IEventAggregator eventService = (System.Windows.Application.Current as App).EventService;
    
        private UserAccountActions userAccountAction;
        public UserAccountActions UserAccountAction 
        {
            get { return userAccountAction; } 
            set 
            {
                userAccountAction = value;
                IsSaveEnabled = (userAccountAction == UserAccountActions.None) ? false : true;
                OnPropertyChanged("UserAccountAction"); 
            } 
        }
    
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
                this.eventService.GetEvent<SaveEnabledEvent>().Publish(this);
            } 
        }
    }
