    public BaseData(SessionObject session)
    {
        Session = session;
        
        var dbConnection = "BasicFinanceEntities";
        if (Session != null && Session.TestModeActive)
        {
            dbConnection = "TestConnection";
        }
        Context = new BasicFinanceEntities(dbConnection);
        Context.Configuration.LazyLoadingEnabled = false;
    }
