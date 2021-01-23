    protected override void Initialize(HttpControllerContext controllerContext)
    {
        foreach (var parameter in controllerContext.Request.GetQueryNameValuePairs())
        {
            Debug.WriteLine(string.Format("{0} = {1}", parameter.Key, parameter.Value));
        }
        base.Initialize(controllerContext);
    }
