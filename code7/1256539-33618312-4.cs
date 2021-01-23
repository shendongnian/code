    public MyWebService ()
            : this(ConnectionString.GetTVConnectionString())
    {
    }
    public MyWebService (string sConnStr)
    {
        msConnStr = sConnStr;
    }
