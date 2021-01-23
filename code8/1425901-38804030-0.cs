    [System.Web.Services.WebMethod]
    public static string LiClick(string item)
    {
        System.Diagnostics.Debugger.Break();
        return String.Format("You clicked on - {0}", item);
    }
