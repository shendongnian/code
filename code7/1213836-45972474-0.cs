    var originalSynchronizationContext = SynchronizationContext.Current;
    try
    {
        SynchronizationContext.SetSynchronizationContext(null);
        new MailController().CreateUser(user.userDetails);
    }
    finally
    {
        SynchronizationContext.SetSynchronizationContext(originalSynchronizationContext);
    }
