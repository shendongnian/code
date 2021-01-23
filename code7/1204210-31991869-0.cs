    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static OLServiceReference.CurrRate getCurr(int id)
    {
        var CR = client.GetCurrRates(id);
        return CR;
    }
