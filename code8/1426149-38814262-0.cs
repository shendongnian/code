    protected void Page_Load(object sender, EventArgs e)
    {
    }
    [System.Web.Services.WebMethod]
    public static string generateString(string id)
    {
        System.Diagnostics.Debugger.Break();
        return String.Format("Response from server for - {0}.Call time - {1}",id,DateTime.Now.ToString("HH:mm:ss"));
    }
