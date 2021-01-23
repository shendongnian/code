    public static SessionInfo SetServiceSession<T>(T service) where T : class
    {
        SessionInfo sessionInfo = GetApiControllerSessionValue();
        //Do something with sessionInfo, if needed
        return sessionInfo;
    }
    private static SessionInfo GetApiControllerSessionValue()
    {
        //Get SessionInfo here.
        //If you need to access any other shared state here, you must need synchronization.
    }
