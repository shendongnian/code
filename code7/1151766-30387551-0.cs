    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(!String.IsNullOrEmpty(Session["CRStatus"]))
            {
                Master.CRStatus = Session["CRStatus"].ToString();
            }
        }
    }
