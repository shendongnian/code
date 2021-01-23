    private static readonly ILog iLog = LogManager.GetLogger(
        MethodBase.GetCurrentMethod().DeclaringType);
    public void Configure(){
        iLog.InfoFormat("Found project '{0}'.", GetProject());
        ... do stuff ...
    }
    private string GetProject()
    {
       string result = null;
       iLog.Debug("Trying to determine project.");
       .... do stuff ...
       return result;
    }
