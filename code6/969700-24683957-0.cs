    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<ListVar> SearchUsers(string searchText, string additionalFilter)
    {
        return WebUserManager.SearchWebUsers(searchText, Boolean.Parse(additionalFilter));
    }
