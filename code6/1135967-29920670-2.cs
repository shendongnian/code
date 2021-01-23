    [WebMethod]
    public static string SearchButtonActivity()
    {
        var result = new List<string>();
        foreach (string value in getCityList())
        {
            result.Add(value);
        }
        return result;
    }
