                //This is not the preferred way  - but it does the job
                public NotificationManager(Action<ActivityStream> dispatcher)
                {
                    _userId = HttpContext.Current.User.Identity.CurrentUserId();
                    _updateNotifier = new DbUpdateNotifier(_userId);
                    _updateNotifier.NewNotification += NewNotificationHandler;
                    unitOfWork = new UnitOfWork();
                    _notificationService = new NotificationService(_userId, unitOfWork);
                    _dispatcher = dispatcher;
                    _updateService = DependencyResolver.Current.GetService<INotificationUpdateService>(); //versus having autofac resolve in the constructor
                }
