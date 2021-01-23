    public void OnSomeEventThatMeansYouCanCreateASubscription(string name)
    {   
        _productState.EnableCreateSubscription(name);     
    }
    public void OnSomeEventThatNeedsToCheckTheState(string name)
    {   
        if (_productState.CanCreateSubscription())     
            _subscriptions.Add(Subscription.Create(name));
    }
