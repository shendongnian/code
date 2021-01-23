      [System.Web.Services.WebMethod]
    public static void storeSessionVars(int? roleId, int? roleIndex)
    {
        HttpContext.Current.Session["roleid"] = roleId;
        HttpContext.Current.Session["roleindex"] = roleIndex;
    }
