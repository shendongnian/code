    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ClickedLink"] = "Contact";
        lblResults.Text = "";
        if (!IsPostBack)
        {
            lblResults.Text = Request.QueryString["msg"].ToString();
        }       
    }
