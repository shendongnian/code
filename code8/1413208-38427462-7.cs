    var mvcUrlPartsDict = new Dictionary<string, string>();
    var routeValues = HttpContext.Request.RequestContext.RouteData.Values;
    if (routeValues.ContainsKey("controller"))
    {
        if (!mvcUrlPartsDict.ContainsKey("controller"))
        {
            mvcUrlPartsDict.Add("controller", string.IsNullOrEmpty(routeValues["controller"].ToString()) ? string.Empty : routeValues["controller"].ToString());
        }
    }
    if (routeValues.ContainsKey("action"))
    {
        if (!mvcUrlPartsDict.ContainsKey("action"))
        {
            mvcUrlPartsDict.Add("action", string.IsNullOrEmpty(routeValues["action"].ToString()) ? string.Empty : routeValues["action"].ToString());
        }
    }
    if (routeValues.ContainsKey("id"))
    {
        if (!mvcUrlPartsDict.ContainsKey("id"))
        {
            mvcUrlPartsDict.Add("id", string.IsNullOrEmpty(routeValues["id"].ToString()) ? string.Empty : routeValues["id"].ToString());
        }
    }
    var url = string.Format("/{0}/{1}/", mvcUrlPartsDict["controller"], mvcUrlPartsDict["action"]);
    Debug.WriteLine(url);
