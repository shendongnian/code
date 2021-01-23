    [WebMethod]
    [ScriptMethod(UseHttpGet = true)]
    public static string GetAttributes(string ProductId)
    {
    List<QuoteAttribute> list = DAL.GetAttributes(ProductId);
    var json = JsonConvert.SerializeObject(list);
    return json;
    }
