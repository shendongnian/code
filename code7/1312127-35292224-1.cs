    public async void BillSubscriptions()
    {
       ProcessSubscriptions(_subscriptionRepository);
       ProcessNonRecurringSubscriptions(_subscriptionRepository);
       ProcessTrialSubscriptions(_subscriptionRepository);
    }
