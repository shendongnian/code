    public HttpResponseMessage Get()
    {
        string userid = UrlUtil.getParam(this, "userid", "");
        string pwd    = UrlUtil.getParam(this, "pwd", "" );
    
        string resp = DynAggrClientAPI.openSession(userid, pwd);
    
        var response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(resp, Encoding.UTF8, "application/json");
        return response;
    }
