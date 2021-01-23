        private ISubscription subscription;
        public User1(NotificationManager notificationManager)
        {
            this.subscription = notificationManager.Subscribe<WakeUpNotification>(
                (notification, subscription) => this.WakeMeUp());
        }
        public void WakeMeUp()
        {
            Console.WriteLine("Ringing User1's Alarm");
        }
        public void Dispose()
        {
            this.subscription.Unsubscribe();
        }
    }
