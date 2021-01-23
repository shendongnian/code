    public JsonResult GetResult(JQueryDataTableParamModel param)
    {
        NameValueCollection qs = HttpUtility.ParseQueryString(Request.QueryString.ToString());
    
        var model = new MyCustomParamModel
        {
            customParam1 = qs["customParam1"],
            customParam2 = qs["customParam2"],
        }
