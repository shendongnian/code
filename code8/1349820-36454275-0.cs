    [AcceptVerbs("OPTIONS")]
    public HttpResponseMessage Options()
    {
        var resp = new HttpResponseMessage(HttpStatusCode.OK);
        resp.Headers.Add("Access-Control-Allow-Origin", "*");
        resp.Headers.Add("Access-Control-Allow-Methods", "GET,DELETE");
        return resp;
    }
