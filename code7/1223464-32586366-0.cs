    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           GridView1.DataSource = ds; // appropriate data source here
           GridView1.DataBind();
        }
    }
