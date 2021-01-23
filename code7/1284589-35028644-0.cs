    internal sealed class ApplicationService
        {
            private ApplicationService() { }
    
            private static readonly ApplicationService _instance = new ApplicationService();
    
            internal static ApplicationService Instance { get { return _instance; } }
    
            private IEventAggregator _eventAggregator;
            internal IEventAggregator EventAggregator
            {
                get
                {
                    if (_eventAggregator == null)
                        _eventAggregator = new EventAggregator();
    
                    return _eventAggregator;
                }
            }
        }
