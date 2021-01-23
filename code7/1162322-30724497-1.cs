    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Gv1.DataSource = Somesource;
            Gv1.DataBind();
        }
    }
