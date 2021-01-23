    public string GetSession_LoggedInUserName()
    {
            SessionConfiguration Obj_Configuration = (SessionConfiguration)Session["Configuration"];
            return Obj_Configuration.LoggedInUserName;
    }
