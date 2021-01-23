    [WebMethod(MessageName="Start", Description="Start", EnableSession=true)]
    public void Start(string application, string version){
        StartHandler(application, version);
    }
    
    [WebMethod(MessageName="Startv2", Description="Startv2", EnableSession=true)]
    public void Start(string application, string version, string exception){
        StartHandler(application, version, exception);
    }
    
        private void StartHandler(string application, string version, string exception = null) {}
