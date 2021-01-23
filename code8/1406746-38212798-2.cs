    protected void Page_Load(object sender, EventArgs e) 
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = // data source
            GridView1.DataBind();
        }
    }
