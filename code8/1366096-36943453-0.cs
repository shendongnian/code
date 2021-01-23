        public NotificationHub()
        {
            _manager = NotificationManager.GetInstance(PushLatestNotifications, HttpContext.Current.Session);
        }
    
