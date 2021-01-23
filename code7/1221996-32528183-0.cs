    public static class Global
    {
        public static int PageRequests;
    }
    ...
    
    protected void Page_Load()
    {
        // This construct without locking might lead to lost counts
        Global.PageRequests++;
    }
