    protected void Page_Load(object sender, EventArgs e)
    {
      Response.Cache.SetCacheability(HttpCacheability.NoCache);
      if (!this.IsPostBack)
      {
        Session["Reset"] = true;
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
        SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
        int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;
        ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", "SessionExpireAlert(" + timeout + ");", true);
      }
    }
