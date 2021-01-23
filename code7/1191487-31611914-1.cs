	[WebMethod]
    public string Query(StaticClass query)
    {
        string SelectDataQuery = query.Query;
        return SelectDataQuery ;
    }
