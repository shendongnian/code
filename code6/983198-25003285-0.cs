    public void Register(UserReportSavePermissionRequestDelegate del)
    {
       ... //do some stuff
       var someVar  = CreateRequest(); // <-- this needs to be the UserReportSavePermissionRequest type
       del(someVar);
    }
