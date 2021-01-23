    [System.Web.Services.WebMethod(true)]
    public static string SetSession(string value)
    {
    	HttpContext.Current.Session["my_sessionValue"] = value;
    	return value;
    }
    
    protected void ShowSessionValue(object sender, EventArgs e)
    {
    	lblSessionText.Text = Session["my_sessionValue"] as string;
    }
