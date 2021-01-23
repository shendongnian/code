        public class NotificationManager
        {
                private static NotificationManager _manager;
                private DateTime _lastRun;
                private DbUpdateNotifier _updateNotifier;
                private readonly INotificationService _notificationService;
                private readonly Action<ActivityStream> _dispatcher;
                private long _userId;
                private IUnitOfWork unitOfWork;
                public NotificationService NotificationService => (NotificationService)_notificationService;
                private readonly INotificationUpdateService _updateService;                                         
                public DbUpdateNotifier UpdateNotifier
                {
                    get { return _updateNotifier; }
                    set { _updateNotifier = value; }
                }
                public static NotificationManager GetInstance(Action<ActivityStream> dispatcher)
                {
                    return _manager ?? new NotificationManager(dispatcher);
                }
                //You'll need to make the constructor accessible for autofac to resolve your dependency
                public NotificationManager(Action<ActivityStream> dispatcher,  INotificationUpdateService updateService)
                {
                    _userId = HttpContext.Current.User.Identity.CurrentUserId();
                    _updateNotifier = new DbUpdateNotifier(_userId);
                    _updateNotifier.NewNotification += NewNotificationHandler;
                    unitOfWork = new UnitOfWork();
                    _notificationService = new NotificationService(_userId, unitOfWork);
                    _dispatcher = dispatcher;
                    _updateService = updateService;
                }
                private void NewNotificationHandler(object sender, SqlNotificationEventArgs evt)
                {
                    //Want to store lastRun variable in a session here
                    //just put the datetime in through the service
                    _updateService.SetLastUpdate(DateTime.Now);
                    var notificationList = _notificationService.GetLatestNotifications();
                    _dispatcher(BuilActivityStream(notificationList));
                }
        }
