    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bool isReloaded;
            int ContentId;
            bool.TryParse(Request.QueryString["reloaded"],out isReloaded);
            int.TryParse(Request.QueryString["contentId"],out ContentId); //I need this value
            if (!isReloaded)
            {
                StringBuilder js = new StringBuilder();
                js.Append("var last = window.top.location.href.substring(window.top.location.href.lastIndexOf('/') + 1, window.top.location.href.length); ");
                js.Append("window.location.href = window.location.href + '?reloaded=true&contentId=' + last;");
                ExecScript(js.ToString());
            }
        }
    }
    void ExecScript(string script)
    {
        Page page = HttpContext.Current.CurrentHandler as Page;
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("AttachedScript"))
        {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "AttachedScript", script, true);
        }
    }
