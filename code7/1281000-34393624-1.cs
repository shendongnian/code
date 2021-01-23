    public static ContinuationManager ContinuationManager { get; private set; }
   
     public App()
    {
        ContinuationManager = new ContinuationManager();
    }
    private void OnSuspending(object sender, SuspendingEventArgs e)
            {
                var deferral = e.SuspendingOperation.GetDeferral();
    #if WINDOWS_PHONE_APP
                ContinuationManager.MarkAsStale();
    #endif
                // TODO: Save application state and stop any background activity
                deferral.Complete();
            }
    protected override void OnActivated(IActivatedEventArgs args)
            {
    #if WINDOWS_PHONE_APP
                if (args.Kind == ActivationKind.WebAuthenticationBrokerContinuation)
                {
                    var continuationEventArgs = args as IContinuationActivatedEventArgs;
                    if (continuationEventArgs != null)
                    {
                        ContinuationManager.Continue(continuationEventArgs);
                        ContinuationManager.MarkAsStale();
                    }
    
                }
    #endif
            }
