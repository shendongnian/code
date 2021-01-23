    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Test t = new Test();
            GridView1.DataSource = t.GetData();
            GridView1.DataBind();
        }
    }
