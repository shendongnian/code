    public bool Process()
    {
        if (ErrorLog != null){
            PublishErrorLog();
            return false;
        }
            //Metadata analysis code that may write errors
           //Note that error log may change here
        if (ErrorLog != null){
            PublishErrorLog();
            return false;
        }
    
        return true;
    }
