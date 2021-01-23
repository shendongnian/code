    public class MyList
    {
        public MyList()
        {
            _notifications =  new List<notificationObject>();
        }
        private List<notificationObject> _notifications;
        public List<notificationObject> notifications
        {
            get { return _notifications; }
            set
            {
                if (_notifications != value)
                {
                    _notifications = value;
                    OnPropertyChanged("notifications");
                    //I am not sure about this bit of code. You may have to test it again after doing this change.
                    //Show new notification
                    //Views.Notification x = new Views.Notification(value);
                    //x.Show();
                }
            }
        }
        public void Add(notificationObject newnotificationObject)
        {
            notifications.Add(newnotificationObject);
            OnPropertyChanged("notifications");
        }
        public void Remove(notificationObject existingnotificationObject)
        {
            if (notifications.Contains(existingnotificationObject))
            {
                notifications.Remove(existingnotificationObject);
                OnPropertyChanged("notifications");
            }
        }
    }
