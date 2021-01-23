    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ClickedLink"] = "Contact";
        lblResults.Text = "";
        if (!IsPostBack)
        {
            if (Request.QueryString["msg"] != null) 
                lblResults.Text = Request.QueryString["msg"];
        }       
    }
