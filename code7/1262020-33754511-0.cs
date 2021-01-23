    private IAsyncResult EstablishApplicationEndpoint()
    {
        ...
        return ApplicationEndpoint.BeginEstablish(OnApplicationEndpointEstablishCompleted, null);
    }
...
    private static void StartPlatform()
    {
        ...
        _platformController.Startup(SendContext);
        var asyncResult = _platformController.EstablishApplicationEndpoint();
        
        // Do other things
        
        // Re-join the callback
        ApplicationEndpoint.EndEstablish(asyncResult);
    }
