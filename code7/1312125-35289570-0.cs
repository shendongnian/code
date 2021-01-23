    public async void BillSubscriptions()
    {
       await Task.WhenAll(
          Task.Run(() => ProcessSubscriptions(_subscriptionRepository));
          Task.Run(() => ProcessNonRecurringSubscriptions(_subscriptionRepository));
          Task.Run(() => ProcessTrialSubscriptions(_subscriptionRepository))
       );
    }
