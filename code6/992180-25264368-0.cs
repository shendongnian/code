    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["jid"] == null)
        {
            rp_jobs_detail.Visible = false;
        }
        else
        {
            DS_Jobs.SelectParameters.Clear();
            DS_Jobs.SelectParameters.Add("Locale", System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToString());
            DS_Jobs.SelectParameters.Add("jid", Request.QueryString["jid"]);
            DS_Jobs.SelectParameters.Add("limit", /* what's the limit? */ );
            rp_jobs_list.Visible = false;
        }
    }
