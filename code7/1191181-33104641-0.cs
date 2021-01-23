    class ManagedForm
    {
        public bool ShowNotifications {get; set;}
        public void OnEventNotification(object sender, ...)
        {
            if (this.ShowNotifications)
            {
                // show the notification
            }
        }
