    public async void BillSubscriptions()
    {
       await Task.Run(() => ProcessSubscriptions(_subscriptionRepository));
       await Task.Run(() => ProcessNonRecurringSubscriptions(_subscriptionRepository));
       await Task.Run(() => ProcessTrialSubscriptions(_subscriptionRepository));
    }
