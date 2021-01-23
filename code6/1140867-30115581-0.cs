    // assume members _messagingFactory, _secondaryNamespaceManager, _secondaryManagementMessagingFactory have been assigned.
    try
    {
        var pairedNamespaceOptions = new SendAvailabilityPairedNamespaceOptions(_secondaryNamespaceManager,
                _secondaryManagementMessagingFactory,
                1,
                TimeSpan.FromSeconds(30),
                true);
        _messagingFactory.PairNamespaceAsync(pairedNamespaceOptions).Wait();
    }
    catch (Exception ex)
    {
        // logging or handle
    }
