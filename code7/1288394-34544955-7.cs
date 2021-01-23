    [WebMethod]
    public string Ping()
    {
        var model = Context.Request.ParseRequest<MyModel>();
        if (string.IsNullOrEmpty(model.AdditionalInfo))
        {
            return "Process msg with old version";
        }
        return "Process msg with new version"; ;
    }
