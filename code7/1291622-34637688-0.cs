    public bool Process()
    {
        if (ErrorLog != null)
            //At this point, the PublishErrorLog should have already been called.
            return false;
        try
        {
            // Do Metadata analysis that may throw errors
        }
        catch (ErrorLogException e)
        {
            PublishErrorLog()
            return false;
        }
        return true;
    }
