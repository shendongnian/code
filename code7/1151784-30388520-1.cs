        private ISubscription subscription;
        public User2(NotificationManager notificationManager)
        {
            this.subscription = notificationManager.Subscribe<StartMyTvNotification>(
                (notification, subscription) => this.StartMyTv());
        }
        public void StartMyTv()
        {
            Console.WriteLine("Ringing User1's Alarm");
        }
        public void Dispose()
        {
            this.subscription.Unsubscribe();
        }
    }
