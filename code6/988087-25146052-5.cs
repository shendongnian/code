    public JObject Get()
    {
        string userid = UrlUtil.getParam(this, "userid", "");
        string pwd    = UrlUtil.getParam(this, "pwd", "" );
    
        string resp = DynAggrClientAPI.openSession(userid, pwd);
        var jObject = JObject.Parse(resp);
        return jObject;
    }
