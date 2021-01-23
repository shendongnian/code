    [WebMethod]
    public static bool DidProcessingSucceed()
    {
        // TODO: Put your processing logic here
        var didSucceed = YourLogic.DoProcessing();
        // Return true if successful, false otherwise
        return didSucceed;
    }
