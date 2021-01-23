    protected override void OnActivated(IActivatedEventArgs args)
    {            
        base.OnActivated(args);
        switch (args.Kind)
        {
            case ActivationKind.WebAuthenticationBrokerContinuation:
                    OnWebAuthenticationBrokerContinuation((WebAuthenticationBrokerContinuationEventArgs)args);
                    break;
            }
    }
    private void OnWebAuthenticationBrokerContinuation(WebAuthenticationBrokerContinuationEventArgs args)
    {
        var eventAggregator = container.GetInstance<IEventAggregator>()
        eventAggregator.PublishOnUIThread(args);
    }
