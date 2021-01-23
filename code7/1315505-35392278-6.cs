    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var dt = GetData();
            gridView.DataSource = dt;
            gridView.DataBind();
        }
    }
    private DataTable GetData()
    {
        var dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Text", typeof(string));
        for (int i = 0; i < 10; i++)
            dt.Rows.Add(new object[] { i, "Test text " + i.ToString() });
        return dt;
    }
