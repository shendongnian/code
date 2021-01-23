    public bool Process()
    {
        if (HasValidConnection)
        {
            //Metadata analysis code that may write errors
        }
        if (ErrorLog == null)
        {
            // no errors establishing the connection neither processing metadata
            return true;
        }
        else
            PublishErrorLog();
        return false;
    }
