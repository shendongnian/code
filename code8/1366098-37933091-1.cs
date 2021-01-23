    public class NotificationUpdateDataProvider : INotificationUpdateDataProvider
    {
        private readonly Dictionary<string, DateTime> _lastUpdateCollection;
        private readonly string _userId;
        private Cache _cache;
        public NotificationUpdateDataProvider()
        {
            _cache = HttpRuntime.Cache;
            _userId = HttpContext.Current.User.Identity.GetUserId();
            _lastUpdateCollection =(Dictionary<string,DateTime>) _cache["LastUpdateCollection"];
            //If null - create it and stuff it in cache
            if (_lastUpdateCollection == null)
            {
                _lastUpdateCollection = new Dictionary<string, DateTime>();
                _cache["LastUpdateCollection"] = _lastUpdateCollection;
            }
        }
        public DateTime LastUpdate
        {
            get { return _lastUpdateCollection[_userId]; }
            set { _lastUpdateCollection[_userId] = value; }
        }
        public string UserId => _userId;
    }
    public class NotificationUpdateService : INotificationUpdateService
    {
        private readonly INotificationUpdateDataProvider _provider;
        public NotificationUpdateService(INotificationUpdateDataProvider provider)
        {
            _provider = provider;
        }
        public DateTime GetLastUpdate()
        {
            return _provider.LastUpdate;
        }
        public void SetLastUpdate(DateTime timestamp)
        {
            _provider.LastUpdate = timestamp;
        }
    }
