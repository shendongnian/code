    [WebMethod]
    public static string GetCitiesState()
    {
        //etcc...
        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(dictionary);
    }
