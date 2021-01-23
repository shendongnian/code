    [WebMethod(EnableSession = true)]
    public static string Test()
    {
        string s = HttpContext.Current.Session["Test"].ToString();
        return s;
    }
