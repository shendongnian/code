    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataTable dt = this.GetData();
            gridView.DataSource = dt;
            gridView.DataBind();
        }
    }
