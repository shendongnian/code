        private ISubscription subscription;
        public MainWindowForm()
        {
            // Anytime any form publishes a `ResultChangedMessage` we will be told of it. We can grab the changed value and use it, without knowing that the 2nd form exists.
            this.subscription = new NotificationManager.Subscribe<ResultChangedMessage>(
                (notification, subscription) => this.LatestResult = notification.Content);
        }
    }
