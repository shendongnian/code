    [System.Web.Services.WebMethod]
    public static Dictionary<string, string> GetTradingTypeToSelect()
    {
        var dict = new Dictionary<string, string>();
        dict.Add("1", "Item 1");
        dict.Add("2", "Item 2");
        return dict;
    }
