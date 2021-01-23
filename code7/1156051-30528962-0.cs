    protected void Page_Load(object sender, EventArgs e)
    {
        GetData();
    }
    public void GetData()
    {
        Chart chart = new Chart();
        string connStr = ConfigurationManager.ConnectionStrings["CRM_SQL"].ConnectionString;
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        SqlCommand query = new SqlCommand(chart.Sql, conn);
        SqlDataReader rst = query.ExecuteReader();
        gridView1.DataSource = rst;
        gridView1.DataBind();
        
    }
