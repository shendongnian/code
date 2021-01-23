    [System.Web.Services.WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string MyMethod(string s)
    {
        return "Method called!";
    }
