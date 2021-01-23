    public void BillSubscriptions()
    {
        Task t1 = Task.Run(() => ProcessSubscriptions(_subscriptionRepository));
        t1.ContinueWith(t =>
        {
            Task t2 = Task.Run(() => ProcessNonRecurringSubscriptions(_subscriptionRepository));
            t2.ContinueWith(tt =>
            {
                Task.Run(() => ProcessTrialSubscriptions(_subscriptionRepository));
            });
        });
    }
